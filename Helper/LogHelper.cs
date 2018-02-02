using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

public class LogHelper
{
    static string LogName
    {
        get
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogName"]))
                return ConfigurationManager.AppSettings["LogName"];
            return System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
        }
    }
    public static void Info(string source, string msg)
    {
        new CchMis.Common.Log(LogName, source).Info(msg);
    }

    public static void Info(string source, Exception ex)
    {
        new CchMis.Common.Log(LogName, source).Info(ex);
    }

    public static void Warning(string source, string msg)
    {
        new CchMis.Common.Log(LogName, source).Warning(msg);
    }
    public static void Warning(string source, Exception ex)
    {
        new CchMis.Common.Log(LogName, source).Warning(ex);
    }

    public static void Error(string source, string msg)
    {
        new CchMis.Common.Log(LogName, source).Error(msg);
    }
    public static void Error(string source, Exception ex)
    {
        new CchMis.Common.Log(LogName, source).Error(ex);
    }
}
