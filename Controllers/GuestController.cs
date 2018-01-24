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
    public class GuestController : Controller
    {


        /// <summary>
        /// 当前在住
        /// </summary>
        /// <returns></returns>
        public Guest NowLiving()
        {
            Guest entity = ApiClient.GetList<Guest>(ApiClient.host + "/Guest/NowLiving");
            return entity;
        }

        /// <summary>
        /// 今天预定
        /// </summary>
        /// <returns></returns>
        public Guest TodayReserve()
        {
            Guest entity = ApiClient.GetList<Guest>(ApiClient.host + "/Guest/TodayReserve");
            return entity;
        }

        /// <summary>
        /// 今天离店
        /// </summary>
        /// <returns></returns>
        public Guest TodayLeave()
        {
            Guest entity = ApiClient.GetList<Guest>(ApiClient.host + "/Guest/TodayLeave");
            return entity;
        }

        /// <summary>
        /// 客人列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomList()
        {
            CustomList entity = new CustomList();
            entity.NowLiving = NowLiving();
            entity.TodayReserve = TodayReserve();
            entity.TodayLeave = TodayLeave();
            return View(entity);
        }
    }
}
