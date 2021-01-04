using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data_Access_Layer;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        double total = 0.0;
        // GET: Cart
        public ActionResult Index()
        {
            List<CartModel> carts = db.Carts.ToList();
            CartModel userCart = carts.FindLast(p => p.CustomerName == User.Identity.Name);

            if(userCart == null)
            {
                userCart = new CartModel();
                db.Carts.Add(userCart);
                db.SaveChanges();
            }

            List<CartItemModel> cartItems = db.CartItems.ToList();

            List<CartItemModel> userCartItems = cartItems.FindAll(p => p.CartId == userCart.Id).ToList();

            List<ProductModel> products = db.Products.ToList();

            List<CartViewModel> cartViewModel = new List<CartViewModel>();
            foreach (var item in userCartItems)
            {
                cartViewModel.Add(new CartViewModel()
                {
                    Item = item,
                    Product = products.Find(p=>p.Id == item.ProductId),
                });
            }

            total = 0.0;
            foreach (var item in cartItems)
            {
                total += item.Quantity * products.Find(p => p.Id == item.ProductId).Price;
            }

            ViewBag.Total = total;
            ViewBag.CartId = userCart.Id;
            return View(cartViewModel);
        }
        public ActionResult AddToCart(int id)
        {
            List<CartModel> carts = db.Carts.ToList();
            CartModel userCart = carts.FindLast(p => p.CustomerName == User.Identity.Name);

            if (userCart == null)
            {
                userCart = new CartModel() { CustomerName = User.Identity.Name };
                db.Carts.Add(userCart);
                db.SaveChanges();
            }

            List<CartItemModel> cartItems = db.CartItems.ToList();

            CartItemModel item = cartItems.Find(p => p.ProductId == id && p.CartId == userCart.Id);

            if (item == null)
            {
                item = new CartItemModel()
                {
                    CartId = userCart.Id,
                    ProductId = id,
                    Quantity = 1,
                };
                db.CartItems.Add(item);
                db.SaveChanges();
            } else
            {
                item.Quantity += 1;
            }

            db.SaveChanges();

            return RedirectToAction("Product","Home");
        }
        public ActionResult MoreItem(int id)
        {
            List<CartItemModel> cartItems = db.CartItems.ToList();

            CartItemModel cartItem = cartItems.Find(p => p.Id == id);

            cartItem.Quantity += 1;

            db.Entry(cartItem).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
        public ActionResult LessItem(int id)
        {
            List<CartItemModel> cartItems = db.CartItems.ToList();

            CartItemModel cartItem = cartItems.Find(p => p.Id == id);
            if(cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }

            db.Entry(cartItem).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
        public ActionResult RemoveItem(int id)
        {
            List<CartItemModel> cartItems = db.CartItems.ToList();

            CartItemModel cartItem = cartItems.Find(p => p.Id == id);

            db.Entry(cartItem).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
        public ActionResult MakeBill(int id, string address)
        {

            if (address == "" || address == null)
            {
                return RedirectToAction("Index", "Cart");
            }

            var cartItems = db.CartItems.ToList().FindAll(p => p.CartId == id);

            var products = db.Products.ToList();

            float total = 0;

            foreach (var item in cartItems)
            {
                total += item.Quantity * (float)products.Find(p => p.Id == item.ProductId).Price;
            }

            BillModel bill = new BillModel()
            {
                CartId = id,
                Total = total,
                Address = address,
                Date = DateTime.Now,
                Status = BillStatusEnum.DANG_CHO.ToString(),
                //Note = ""
            };


            

            db.Bill.Add(bill);

            db.Carts.Add(new CartModel() { CustomerName = User.Identity.Name });

            db.SaveChanges();

            return View("MakeBill");
        }
    }
}