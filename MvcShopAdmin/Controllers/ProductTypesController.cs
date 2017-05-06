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
    public class ProductTypesController : Controller
    {
        private ShopdbContext db = new ShopdbContext();

        // GET: ProductTypes
        public ActionResult Index()
        {
            ViewBag.ParentTypeId = new SelectList(db.ProductTypes, "Id", "TypeName");
            return View(db.ProductTypes.ToList());
        }

        //// GET: ProductTypes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductType productType = db.ProductTypes.Find(id);
        //    if (productType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productType);
        //}

        //// GET: ProductTypes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string TypeName, int ParentTypeId)
        {
            if (ModelState.IsValid)
            {
                var productType = new ProductType()
                {
                    TypeName = TypeName,
                    ParentTypeId = ParentTypeId
                };
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // GET: ProductTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentTypeId = new SelectList(db.ProductTypes, "Id", "TypeName");

            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeName,ParentTypeId")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);

            if (productType == null)
            {
                return HttpNotFound();
            }

            ViewBag.parentTypeName = "";
            if (productType.ParentTypeId != 0)
            {
                var parentType = db.ProductTypes.SingleOrDefault(i => i.Id == productType.ParentTypeId);
                if (parentType != null)
                {
                    ViewBag.parentTypeName = parentType.TypeName;
                }
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductType productType = db.ProductTypes.Find(id);
            db.ProductTypes.Remove(productType);
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
