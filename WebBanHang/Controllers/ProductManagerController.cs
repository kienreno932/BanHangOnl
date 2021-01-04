using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data_Access_Layer;
using WebBanHang.Business_Logic_Layer;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductManagerController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: ProductManager
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: ProductManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);

            if (productModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = db.Categories.Find(productModel.CategoryId);
            ViewBag.Supplier = db.Suppliers.Find(productModel.SupplierId);
            return View(productModel);
        }

        // GET: ProductManager/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: ProductManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageName,Description,Price,CategoryId,SupplierId")] ProductModel productModel, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    productModel.ImageName = PhotoHelper.SaveToServer(photo);
                }

                db.Products.Add(productModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", productModel.SupplierId);
            return View(productModel);
        }

        // GET: ProductManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", productModel.SupplierId);
            return View(productModel);
        }

        // POST: ProductManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageName,Description,Price,CategoryId,SupplierId")] ProductModel productModel, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    productModel.ImageName = PhotoHelper.SaveToServer(photo);
                }

                db.Entry(productModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", productModel.SupplierId);
            return View(productModel);
        }

        // GET: ProductManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: ProductManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModel productModel = db.Products.Find(id);
            db.Products.Remove(productModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
