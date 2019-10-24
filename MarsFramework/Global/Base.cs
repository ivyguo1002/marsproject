using MarsFramework.Config;
using RelevantCodes.ExtentReports;
using System.IO;
using static MarsFramework.Global.GlobalDefinitions;
using System;

namespace MarsFramework.Global
{
    public class Base
    {
        #region To access Path from resource file
        //Get base directory
        public static string baseDir = AppDomain.CurrentDomain.BaseDirectory.Replace(@"MarsAutomation\bin\Debug", @"MarsFramework");
        public static int Browser = int.Parse(MarsResource.Browser);
        public static string ExcelPath = baseDir + MarsResource.ExcelPath;
        public static string ScreenshotPath = baseDir + MarsResource.ScreenShotPath;
        public static string ReportPath = baseDir + MarsResource.ReportPath;
        public static string WorkSamplePath = baseDir + MarsResource.WorkSamplePath;
        public static string ReportXMLPath = baseDir + MarsResource.ReportXMLPath;
        public static string Url = MarsResource.Url;
        public static string IsLogin = MarsResource.IsLogin;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion
    }     
}