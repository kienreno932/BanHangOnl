using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data_Access_Layer;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierManagerController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: SupplierManager
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: SupplierManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierModel supplierModel = db.Suppliers.Find(id);
            if (supplierModel == null)
            {
                return HttpNotFound();
            }
            return View(supplierModel);
        }

        // GET: SupplierManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,Address")] SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplierModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierModel);
        }

        // GET: SupplierManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierModel supplierModel = db.Suppliers.Find(id);
            if (supplierModel == null)
            {
                return HttpNotFound();
            }
            return View(supplierModel);
        }

        // POST: SupplierManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,Address")] SupplierModel supplierModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierModel);
        }

        // GET: SupplierManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierModel supplierModel = db.Suppliers.Find(id);
            if (supplierModel == null)
            {
                return HttpNotFound();
            }
            return View(supplierModel);
        }

        // POST: SupplierManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierModel supplierModel = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplierModel);
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
