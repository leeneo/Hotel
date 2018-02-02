using WeChat.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility.Web;

namespace WeChat.Helper
{
    /// <summary>
    /// 用户客户端Cookies信息记录，记录用户名，个人照片
    /// 不作为是否是已登录状态的标准
    /// </summary>
    public class CookieOperate
    {
        public bool Clear()
        {
            CookieHelper.SetCookie(Constant.CookieUserName, "");
            CookieHelper.SetCookie(Constant.CookieUserPhoto, "");
            CookieHelper.SetCookie(Constant.CookieMemberID, "0");
            CookieHelper.SetCookie(Constant.CookieWeChatOpenId, "");
            CookieHelper.SetCookie(Constant.CookieTicket, "");
            CookieHelper.SetCookie(Constant.CookieHand, "");
            CookieHelper.SetCookie(Constant.CookieS_no, "");
            CookieHelper.SetCookie(Constant.CookieConfig, "");
            CookieHelper.SetCookie(Constant.CookieSID, "0");
            CookieHelper.SetCookie(Constant.CookieSname, "请选择分店");
            return true;
        }
        public int MemberID
        {
            get
            {
                var result = 0;
                try
                {
                    var CookieMemberID = CookieHelper.GetCookieValue(Constant.CookieMemberID);
                    result = Convert.ToInt32(Utility.Cryptography.DESEncrypt.Decrypt(CookieMemberID));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieMemberID, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddDays(7));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
            }
        }
        public string UserName
        {
            get
            {
                var result = "";
                try
                {
                    var CookieUserName = CookieHelper.GetCookieValue(Constant.CookieUserName);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(CookieUserName);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端CookieUserName异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieUserName, Utility.Cryptography.DESEncrypt.Encrypt(value));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端CookieUserName异常: \r\n" + ex.Message.ToString());
                }
            }
        }
        public string WeChatOpenId
        {
            get
            {
                var result = "";
                try
                {
                    var CookieUserName = CookieHelper.GetCookieValue(Constant.CookieWeChatOpenId);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(CookieUserName);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端WeChatOpenId异常: \r\n" + ex.Message.ToString());
                }
                return result;
                //return "o-4S_jiyBnGpY_3sz9DxdZYJDz-g";
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieWeChatOpenId, Utility.Cryptography.DESEncrypt.Encrypt(value), DateTime.Now.AddDays(365));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri
                        + "写入客户端WeChatOpenId异常: \r\n" + ex.Message.ToString() + "\r\n" + value);
                }
            }
        }

        public string UserPhoto
        {
            get
            {
                var result = "";
                try
                {
                    var CookieUserPhoto = CookieHelper.GetCookieValue(Constant.CookieUserPhoto);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(CookieUserPhoto);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端UserPhoto异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieUserPhoto, Utility.Cryptography.DESEncrypt.Encrypt(value));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端UserPhoto异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string Hand
        {
            get
            {
                var result = "";
                try
                {
                    var hand = CookieHelper.GetCookieValue(Constant.CookieHand);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(hand);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端Hand异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieHand, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddHours(24));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端Hand异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string S_no
        {
            get
            {
                var result = "";
                try
                {
                    var hand = CookieHelper.GetCookieValue(Constant.CookieS_no);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(hand);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端S_no异常: \r\n" + ex.Message.ToString());
                }
                return string.IsNullOrEmpty(result) ? "Default" : result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieS_no, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddYears(1));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端S_no异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string Sname
        {
            get
            {
                var result = "";
                try
                {
                    var hand = CookieHelper.GetCookieValue(Constant.CookieSname);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(hand);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端Sname异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieSname, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddYears(1));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端Sname异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string Sconfig
        {
            get
            {
                var result = "";
                try
                {
                    var hand = CookieHelper.GetCookieValue(Constant.CookieConfig);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(hand);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端Sconfig异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieConfig, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddYears(1));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端Sconfig异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        public string ticket
        {
            get
            {
                var result = "";
                try
                {
                    var CookieUserName = CookieHelper.GetCookieValue(Constant.CookieTicket);
                    result = Utility.Cryptography.DESEncrypt.Decrypt(CookieUserName);
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端CookieUserName异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieTicket, Utility.Cryptography.DESEncrypt.Encrypt(value), DateTime.Now.AddDays(30));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端CookieUserName异常: \r\n" + ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// 当前订单索引
        /// </summary>
        public int OrderIndex
        {
            get
            {
                var result = 0;
                try
                {
                    var CookieMemberID = CookieHelper.GetCookieValue(Constant.CookieOrderIndex);
                    result = Convert.ToInt32(Utility.Cryptography.DESEncrypt.Decrypt(CookieMemberID));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieOrderIndex, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddDays(7));
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "CookieOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// 总店id
        /// </summary>
        public int sID
        {
            get
            {
                var result = 0;
                try
                {
                    var CookieMemberID = CookieHelper.GetCookieValue(Constant.CookieSID);
                    result = Convert.ToInt32(Utility.Cryptography.DESEncrypt.Decrypt(CookieMemberID));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "验证客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    CookieHelper.SetCookie(Constant.CookieSID, Utility.Cryptography.DESEncrypt.Encrypt(value.ToString()), DateTime.Now.AddDays(7));
                }
                catch (Exception ex)
                {
                    LogHelper.Info("CookieOperate", HttpContext.Current.Request.Url.AbsoluteUri + "写入客户端MemberID异常: \r\n" + ex.Message.ToString());
                }
            }
        }
    }
}