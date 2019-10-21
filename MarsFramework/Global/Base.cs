using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        public static string baseDir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        public static int Browser = int.Parse(MarsResource.Browser);
        public static string ExcelPath = baseDir+MarsResource.ExcelPath;
        public static string ScreenshotPath = baseDir+MarsResource.ScreenShotPath;
        public static string ReportPath = baseDir+MarsResource.ReportPath;
        public static string WorkSamplePath = baseDir + MarsResource.WorkSamplePath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {

                case 1:
                    Driver = new FirefoxDriver();
                    break;
                case 2:
                    //Add the language option, because my local os is chinese version
                    var options = new ChromeOptions();
                    options.AddArgument("--lang=en-nz");
                    Driver = new ChromeDriver(options);
                    Driver.Manage().Window.Maximize();
                    break;
            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);

            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.Register();
            }

            //Set Implicit Wait
            Wait(20);
        }


        [TearDown]
        public void TearDown()
        {
            //Get test restult
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            // Screenshot
            string screenShotPath = SaveScreenShotClass.SaveScreenshot(Driver, TestContext.CurrentContext.Test.Name);

            // Write log to report
            LogStatus logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    test.Log(logstatus, "Test ended with " + logstatus + "–" + stacktrace + errorMessage);
                    test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
                    break;
                case TestStatus.Passed:
                    logstatus = LogStatus.Pass;
                    test.Log(logstatus, "Test ended with " + logstatus);
                    test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
                    break;
            }

            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver      
            Driver.Close();
            Driver.Quit();
        }
        #endregion

    }
}