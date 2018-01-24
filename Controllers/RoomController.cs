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
    public class RoomController : Controller
    {
        /// <summary>
        /// 实时房态
        /// </summary>
        /// <date>日期</date>
        /// <returns></returns>
        public ActionResult RealRoomState()
        {
            RealTimeState list = ApiClient.GetList<RealTimeState>(ApiClient.host + "/Room/RealTimeRoom");
            return View(list);
        }

        /// <summary>
        /// 远期房态
        /// </summary>
        /// <roomtype>房间类型</roomtype>
        /// <returns></returns>
        public ActionResult HistoryState(string roomtype)
        {
            string url = "/Room/HistoryState";
            if (!string.IsNullOrEmpty(roomtype))
                url = "/Room/HistoryState?roomtype=" + roomtype;

            List<HistoryState> list = ApiClient.GetList<List<HistoryState>>(ApiClient.host + url);
            return View(list);
        }

        /// <summary>
        /// 房间类型
        /// </summary>
        /// <returns></returns>
        public ActionResult RoomType()
        {
            List<RoomType> list = ApiClient.GetList<List<RoomType>>(ApiClient.host + "/Room/RoomType");
            return View(list);
        }
    }
}
