using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChat.Helper
{
    public class SessionOperate
    {
        public bool Clear()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            return true;
        }
        public int MemberID
        {
            get
            {
                int result = 0;
                try
                {
                    var SessionAdminId = HttpContext.Current.Session[Constant.SessionMemberID];
                    if (SessionAdminId != null)
                    {
                        result = Convert.ToInt32(Utility.Cryptography.DESEncrypt.Decrypt(SessionAdminId.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证SessionAdminId异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.SessionMemberID] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入SessionAdminId异常: \r\n" + ex.Message.ToString());
                }
            }
        }
        public int AdminId
        {
            get
            {
                int result = 0;
                try
                {
                    var SessionAdminId = HttpContext.Current.Session[Constant.SessionAdminId];
                    if (SessionAdminId != null)
                    {
                        result = Convert.ToInt32(Utility.Cryptography.DESEncrypt.Decrypt(SessionAdminId.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证SessionAdminId异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.SessionAdminId] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入SessionAdminId异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string LogInVerifyCode
        {
            get
            {
                string result = "";
                try
                {
                    var Sessions_no = HttpContext.Current.Session[Constant.Sessions_LogInVerifyCode];
                    if (Sessions_no != null)
                    {
                        result = Utility.Cryptography.DESEncrypt.Decrypt(Sessions_no.ToString());
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证Sessions_no异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.Sessions_LogInVerifyCode] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入Sessions_no异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string MobileRegisterVerifyCode
        {
            get
            {
                string result = "";
                try
                {
                    var Sessions_no = HttpContext.Current.Session[Constant.Sessions_MobileRegisterVerifyCode];
                    if (Sessions_no != null)
                    {
                        result = Utility.Cryptography.DESEncrypt.Decrypt(Sessions_no.ToString());
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证Sessions_no异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.Sessions_MobileRegisterVerifyCode] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入Sessions_no异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string MobileLockCardVerifyCode
        {
            get
            {
                string result = "";
                try
                {
                    var Sessions_no = HttpContext.Current.Session[Constant.Sessions_MobileLockCardVerifyCode];
                    if (Sessions_no != null)
                    {
                        result = Utility.Cryptography.DESEncrypt.Decrypt(Sessions_no.ToString());
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证Sessions_no异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.Sessions_MobileLockCardVerifyCode] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入Sessions_no异常: \r\n" + ex.Message.ToString());
                }
            }
        }

        public string MobileBindMobileVerifyCode
        {
            get
            {
                string result = "";
                try
                {
                    var Sessions_no = HttpContext.Current.Session[Constant.Sessions_MobileBindMobileVerifyCode];
                    if (Sessions_no != null)
                    {
                        result = Utility.Cryptography.DESEncrypt.Decrypt(Sessions_no.ToString());
                    }
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "验证Sessions_no异常: \r\n" + ex.Message.ToString());
                }
                return result;
            }
            set
            {
                try
                {
                    HttpContext.Current.Session[Constant.Sessions_MobileBindMobileVerifyCode] = Utility.Cryptography.DESEncrypt.Encrypt(value.ToString());
                }
                catch (Exception ex)
                {
                    new CchMis.Common.Log("CCWeChat", "SessionOperate").Info(HttpContext.Current.Request.Url.AbsoluteUri + "写入Sessions_no异常: \r\n" + ex.Message.ToString());
                }
            }
        }
    }
}