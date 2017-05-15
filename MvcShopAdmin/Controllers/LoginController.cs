using Model.DbModel;
using MvcShop.Common;
using MvcShopAdmin.Common;
using MvcShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userModel = new UserModel();
                var result = userModel.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = userModel.GetByUserName(model.UserName);
                    var userSession = new UserLogin {
                        UserID = user.Id,
                        UserName = user.UserName
                    };
                    
                    Session.Add(SessionConstant.Admin_Session, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }

            }

            return View("Index");

        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        // edit TaiKhoan
        [HttpGet]
        public ActionResult Edit_TaiKhoan()
        {
            if (Session[SessionConstant.Admin_Session] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View("ConfirmPassword");
        }
        [HttpGet]
        public ActionResult Update_TaiKhoan(int id_TaiKhoan)
        {
            if (Session[SessionConstant.Admin_Session] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session[SessionConstant.ConfirmPassword] == null)
            {
                return View("ConfirmPassword");
            }

            // edit here
            if ((bool)Session[SessionConstant.ConfirmPassword])
            {
                
                //TaiKhoanModel taikhoan = await TaiKhoan.GetTaiKhoanAsync(id_TaiKhoan);
                //var model = new UpdateTaiKhoanModel
                //{
                //    HoTen = taikhoan.HoTen,
                //    Email = taikhoan.Email,
                //    SDT = taikhoan.SDT
                //};

                return View();
            }
            // confirm password false
            
            TempData["message"] = "Mật khẩu không đúng";
            return View("ConfirmPassword");
        }

        [HttpPost]
        public ActionResult Update_TaiKhoan(string newPassword, string newPassword_confirm)
        {
            if (Session[SessionConstant.Admin_Session] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session[SessionConstant.ConfirmPassword] == null)
            {
                return View("ConfirmPassword");
            }
            if (ModelState.IsValid)
            {
                if (newPassword == "")
                {
                    ModelState.AddModelError("", "Mật khẩu không được để trống");
                    return View();
                }

                if (newPassword != newPassword_confirm)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp");
                    return View();
                }
                // processing edit here
                if ((bool)Session[SessionConstant.ConfirmPassword])
                {
                    var account = (UserLogin)Session[SessionConstant.Admin_Session];
                    var model = new UserModel();

                    var result = model.Update_Account(account.UserName, Encryptor.MD5Hash(newPassword));
                    if (result)
                    {
                        ViewBag.Message = "Cập nhật thành công.";
                        Session.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "Cập nhật thất bại.";
                    }

                    return View("Message");
                }
            }
            // confirm password false

            return View("ConfirmPassword");
        }

        [HttpPost]
        public ActionResult ConfirmPassword(string password)
        {
            if (Session[SessionConstant.Admin_Session] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Session[SessionConstant.ConfirmPassword] = false;

            // confirm password here
            var current_account = (UserLogin)Session[SessionConstant.Admin_Session];

            try
            {
                var model = new UserModel();
                var confirm_Result = model.ConfirmPassword(current_account.UserName, Encryptor.MD5Hash(password));

                Session[SessionConstant.ConfirmPassword] = confirm_Result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return RedirectToAction("Update_TaiKhoan", "Login", new { id_TaiKhoan = current_account.UserID});
        }

    }
}