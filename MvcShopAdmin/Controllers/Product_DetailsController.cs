using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Framework;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Threading;

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

            var heatType = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Lạnh", Value = "0"},
                new SelectListItem{ Text = "Nóng lạnh", Value = "1"}
            };
            ViewBag.HeatType = new SelectList(heatType, "Value", "Text");
            return View();
        }

        // POST: Product_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ProductCode,ProductName,ProductDetail,OldPrice,NewPrice,ProductImages,HeatType,ProductWeight,ProductDimension,InsertDate,ProductOrder,ProductStatus,ProductType_Id,Brand_Id")] Product_Details product_Details)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Product_Details.Add(product_Details);
        //        db.SaveChanges();
        //        return RedirectToAction("Create");
        //    }

        //    foreach (string file in Request.Files)
        //    {
        //        System.Diagnostics.Debug.WriteLine(file);
        //    }
        //    ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName", product_Details.Brand_Id);
        //    ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName", product_Details.ProductType_Id);
        //    return View(product_Details);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_Details product_Details)
        {
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];

                var res = UploadImgAsync(postedFile).ToString();
                product_Details.ProductImages = res;


                //System.Diagnostics.Debug.WriteLine(file);

                //var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                //var filePath = HttpContext.Server.MapPath("~/Uploads/" + fileName);

                //postedFile.SaveAs(filePath);
            }
            if (ModelState.IsValid)
            {
                db.Product_Details.Add(product_Details);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "BrandName", product_Details.Brand_Id);
            ViewBag.ProductType_Id = new SelectList(db.ProductTypes, "Id", "TypeName", product_Details.ProductType_Id);
            return View(product_Details);
        }

        private async Task<string> UploadImgAsync(HttpPostedFileBase file)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://mvcshopuploadimages.gear.host/api/Files/Upload");

                //client.BaseAddress = new Uri("http://localhost:54777/api/Files/Upload");

                using (var content = new MultipartFormDataContent())
                {
                    byte[] fileBytes = new byte[file.InputStream.Length + 1]; file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    content.Add(fileContent);
                    var result = await client.PostAsync(client.BaseAddress, content);

                    var url = result.Content.ReadAsStringAsync().Result;


                    System.Diagnostics.Debug.WriteLine(url);

                    return url;
                }
            }
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

        private string formatUrl(string originalUrl)
        {
            int startIndex = originalUrl.IndexOf("www");
            originalUrl = originalUrl.Substring(startIndex, originalUrl.Length - startIndex - 1).Replace("\\", "/").Replace("//", "/");
            string newUrl = "http://" + originalUrl;

            return newUrl;
        }
    }
}
