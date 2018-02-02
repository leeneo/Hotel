using CchMis.Common;
using WeChat.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEntites;

namespace CchMis.WeChat.Filters
{
    /// <summary>
    /// 后台配置页面登录验证。
    /// </summary>
    public class LoginCheckAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            string token = httpContext.Application["token"].ToString();
            string key = DateTime.Now.ToString("yyyy#MM#dd");

            
            LogHelper.Info("LoginCheckAttribute", "Token for Authorize:" + token);

            if (!string.IsNullOrEmpty(token))
            {
                string value = Encryption.AESDecrypt(token,key);
                if (DateTime.Now.ToString("yyyy-MM-dd") == value)
                    return true;
            }
            HttpCookie cookieAccount = httpContext.Request.Cookies["account"];
            HttpCookie cookiePwd = httpContext.Request.Cookies["pwd"];
            if (cookieAccount == null || cookiePwd == null)
                return false;
            //解密cookie中存放的账号和密码。
            string account = Encryption.AESDecrypt(cookieAccount.Value);
            string pwd = Encryption.AESDecrypt(cookiePwd.Value);

            //检查cookie和session中的账号和密码是否匹配。
            var saccount = httpContext.Session["account"];
            var spwd = httpContext.Session["pwd"];
            if (saccount != null && spwd != null && account == saccount.ToString() && pwd == spwd.ToString())
                return true;
            else
            {
                //检查cookie中存放的账号和密码是否与数据库中的匹配。
                //var user = rep.GetModel<ct_operator>(x => x.s_work_no == account && x.s_password == pwd);
                var user = ApiClient.Get<@operator>("/Operator/get/" + account);
                if (user.s_password == pwd)
                {
                    httpContext.Session["account"] = user.s_work_no;
                    httpContext.Session["pwd"] = user.s_password;
                    return true;
                }
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Management/Login?errMsg=权限验证失败");
            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}