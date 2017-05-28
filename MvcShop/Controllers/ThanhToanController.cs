using Model.DbModel;
using Model.Object;
using MvcShop.Helper;
using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            var model = new BillingInfo();

            var helperModel = new Get_SelectList();

            var listThanhPho = helperModel.Get_ThanhPho();
            var listQuan = helperModel.Get_Quan();

            ViewBag.City_ID = new SelectList(listThanhPho, "Id", "Name");
            ViewBag.District_ID = new SelectList(listQuan, "Id", "Name");

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(BillingInfo info)
        {
            CheckoutModel model = new CheckoutModel()
            {
                Info = new CheckoutInfo
                {
                    BillingInfo = info
                }
            };
            // get Cart list items from sesion
            var sesionList = (List<CartItem>)Session["CART_SESSION"];

            CartModel cartModel = new CartModel();

            if (sesionList != null)
            {
                cartModel.get_Item_Details(sesionList);
            }
            else
            {
                List<CartItem> list = new List<CartItem>();
                cartModel.itemList = list;
            }

            model.Info.CartItems = cartModel.itemList;

            // create orders
            var helper = new Cart_CheckoutModel();
            try
            {
                helper.Create_Order_Infomation(model.Info);
                ViewBag.isSuccess = true;
            }
            catch (Exception ex)
            {
                ViewBag.isSuccess = false;
            }
            

            return View("ThongBao");
        }
        
        [Route("Checkout/Get_Quan")]
        public JsonResult Get_Quan(int ID_ThanhPho)
        {            
            var helperModel = new Get_SelectList();

            var listQuan = helperModel.Get_Quan(ID_ThanhPho);

            return Json(listQuan, JsonRequestBehavior.AllowGet);            
        }
        [Route("Checkout/Success")]
        public ActionResult Success()
        {
            ViewBag.Message = "";
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}