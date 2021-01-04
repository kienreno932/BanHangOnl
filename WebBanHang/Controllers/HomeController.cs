using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebBanHang.Data_Access_Layer;
using WebBanHang.Models;
using System.Net;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            var productsHome = products.Take(5);
            return View(productsHome);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Manager()
        {
            return View();
        }

        public ActionResult Product()
        {
            var products = db.Products.Include(p => p.Category).Include(p=> p.Supplier);
            return View(products);
        }


        public ActionResult SearchByName(string searchName)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();

            var findResultProduct = products.FindAll(p => p.Name == searchName);

            return View("Product", findResultProduct);
        }

        public ActionResult SearchByPrice(int searchMin, int searchMax)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();

            var findResultProduct = products.FindAll(p => p.Price >= searchMin && p.Price <= searchMax);

            return View("Product", findResultProduct);
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
        public ActionResult MienPhiVanChuyen()
        {
            return View();
        }
    }
}