using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Framework;

namespace MvcShopAdmin.Controllers
{
    public class Product_DetailsController : Controller
    {
        private ShopdbContext db = new ShopdbContext();

        // GET: Product_Details
        public ActionResult Index()
        {
            var product_Details = db.Product_Details.Include(p => p.Brand).Include(p => p.ProductType);
            return View(product_Details.ToList());
        }

        // GET: Product_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Details product_Details = db.Product_Details.Find(id);
            if (product_Details == null)
            {
                return HttpNotFound();
            }
            return View(product_Details);
        }

        // GET: Product_Details/Create
        public ActionResult Create()
        {
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName");
            return View();
        }

        // POST: Product_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductCode,ProductName,ProductDetail,OldPrice,NewPrice,ProductImages,HeatType,ProductWeight,ProductDimension,InsertDate,ProductOrder,ProductStatus,ProductType_Id,Brand_Id")] Product_Details product_Details)
        {
            if (ModelState.IsValid)
            {
                db.Product_Details.Add(product_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName", product_Details.Brand_Id);
            ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName", product_Details.ProductType_Id);
            return View(product_Details);
        }

        // GET: Product_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Details product_Details = db.Product_Details.Find(id);
            if (product_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName", product_Details.Brand_Id);
            ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName", product_Details.ProductType_Id);
            return View(product_Details);
        }

        // POST: Product_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductCode,ProductName,ProductDetail,OldPrice,NewPrice,ProductImages,HeatType,ProductWeight,ProductDimension,InsertDate,ProductOrder,ProductStatus,ProductType_Id,Brand_Id")] Product_Details product_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName", product_Details.Brand_Id);
            ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName", product_Details.ProductType_Id);
            return View(product_Details);
        }

        // GET: Product_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Details product_Details = db.Product_Details.Find(id);
            if (product_Details == null)
            {
                return HttpNotFound();
            }
            return View(product_Details);
        }

        // POST: Product_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Details product_Details = db.Product_Details.Find(id);
            db.Product_Details.Remove(product_Details);
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
