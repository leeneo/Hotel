using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChat.Helper
{
    public class Constant
    {
        public const string SystemModule = "CchMis.WeChat.";
        public const string CookieUserName = SystemModule + "UserName";
        public const string CookieUserPhoto = SystemModule + "UserPhoto";
        public const string SessionAdminId = SystemModule + "AdminId";
        public const string SessionMemberID = SystemModule + "MemberID";
        public const string CookieMemberID = SystemModule + "MemberID";
        public const string CookieMemberInfo = SystemModule + "CookieMemberInfo";

        public const string CookieOrderIndex = SystemModule + "CookieOrderIndex";
        /// <summary>
        /// 总店id
        /// </summary>
        public const string CookieSID = SystemModule + "MemberSID";

        /// <summary>
        /// 微信openId
        /// </summary>
        public const string CookieWeChatOpenId = SystemModule + "WeChatOpenId";

        /// <summary>
        /// 获取二维码
        /// </summary>
        public const string CookieTicket = SystemModule + "ticket";
        public const string CookieHand = SystemModule + "CookieHand";
        /// <summary>
        /// 登录验证码
        /// </summary>
        public const string Sessions_LogInVerifyCode = SystemModule + "LogInVerifyCode";
        /// <summary>
        /// 分店号
        /// </summary>
        public const string CookieS_no = "CookieS_no";
        /// <summary>
        /// 分店名称
        /// </summary>
        public const string CookieSname = "CookieSname";
        /// <summary>
        /// 分店数据连接
        /// </summary>
        public const string CookieConfig = "CookieConfig";

        /// <summary>
        /// 注册手机验证码
        /// </summary>
        public const string Sessions_MobileRegisterVerifyCode = SystemModule + "Sessions_MobileRegisterVerifyCode";

        /// <summary>
        /// 绑定会员卡手机验证码
        /// </summary>
        public const string Sessions_MobileLockCardVerifyCode = SystemModule + "Sessions_MobileLockCardVerifyCode";

        /// <summary>
        /// 绑定手机号手机验证码
        /// </summary>
        public const string Sessions_MobileBindMobileVerifyCode = SystemModule + "Sessions_MobileBindMobileVerifyCode";
    }
}