using CchMis.Common;
using HotelEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.Helper;

namespace WeChat.Controllers
{
    public class ManagementController : Controller
    {
        //
        // GET: /Management/

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public JsonResult LoginSubmit(string account, string pwd)
        {
            string rspTxt = String.Empty;
            var user = ApiClient.Get<@operator>("/Operator/get/" + account);
            if (user == null || user.s_password != pwd)
                rspTxt = "用户名或密码错误";
            else if (user.s_password == pwd)
            {
                rspTxt = "登录成功";
                Session["account"] = user.s_work_no;
                Session["pwd"] = user.s_password;
                HttpCookie account_cookie = new HttpCookie("account");
                account_cookie.Value = Encryption.AESEncrypt(user.s_work_no);
                account_cookie.Expires = DateTime.Now.AddDays(7);
                HttpCookie pwd_cookie = new HttpCookie("pwd");
                pwd_cookie.Value = Encryption.AESEncrypt(user.s_password);
                pwd_cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(account_cookie);
                Response.Cookies.Add(pwd_cookie);
                return Json(new { success = true, msg = rspTxt });
            }
            else
                rspTxt = "服务器异常";
            return Json(new { success = false, msg = rspTxt });
        }

        public ActionResult Center()
        {

            return View();
        }

        public ActionResult LogOut()
        {
            Response.Cookies.Clear();
            Response.Redirect("/Management/Login");
            return Content("");
        }


        public ActionResult EditPassword()
        {
            try
            {
                var decode = Encryption.AESDecrypt(Request["account"]);
                var updatepwd = Request["pwd"];
                var user = ApiClient.Get<@operator>("/Operator/UpdatePwd/" + decode);
                if (user == null)
                {
                    return Json(new { success = false, msg = "修改密码失败" }, JsonRequestBehavior.AllowGet);
                }
                user.s_password = updatepwd;
                ApiClient.Update<@operator>(user);
                Session["pwd"] = updatepwd;
                return Json(new { success = true, msg = "密码修改成功" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                LogHelper.Error("密码修改异常", e.GetBaseException());
                return Json(new { success = false, msg = "密码修改异常" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
