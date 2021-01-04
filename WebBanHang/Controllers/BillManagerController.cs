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
    public class BillManagerController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Bill
        public ActionResult Index()
        {
            var bill = db.Bill.Include(b => b.Cart);
            return View(bill.ToList());
        }

        public ActionResult IndexCus()
        {
            var bill = db.Bill.Include(b => b.Cart);
            return View(bill.ToList());
        }


        // GET: Bill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillModel billModel = db.Bill.Find(id);
            if (billModel == null)
            {
                return HttpNotFound();
            }
            return View(billModel);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillModel billModel = db.Bill.Find(id);
            db.Bill.Remove(billModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillModel billModel = db.Bill.Find(id);
            if (billModel == null)
            {
                return HttpNotFound();
            }
            return View(billModel);
        }

        // POST: ProductManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Total, Address, CartId, Status, Note")] BillModel billModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billModel);
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
