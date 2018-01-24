using CchMis.WeChat.Filters;
using QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.Helper;

namespace WeChat.Controllers
{
    [LoginCheckAttribute]
    public class BusinessController : Controller
    {
        /// <summary>
        /// 营业日报
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ActionResult DailyReport(string date)
        {
            List<DailyReport> list;
            if (!string.IsNullOrEmpty(date))
                list = ApiClient.GetList<List<DailyReport>>(ApiClient.host + "/Business/DailyReport?date=" + date);
            else
                list = new List<DailyReport>();
            return View(list);
        }
    }
}
