using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class ThongTinSanPhamController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index()
        {
            int defaultId = 1;
            ProductDetailsModel model = new ProductDetailsModel(defaultId);
            
            return View(model);
        }
        //
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetailsModel model = new ProductDetailsModel(id);

            return View(model);
        }



        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}