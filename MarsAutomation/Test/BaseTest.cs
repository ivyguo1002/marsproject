using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsAutomation.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;


namespace MarsAutomation.Test
{
    public  class BaseTest:Base
    {
        #region setup and tear down
        [SetUp]
        public virtual void Inititalize()
        {
            switch (Browser)
            {

                case 1:
                    Driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    Driver.Navigate().GoToUrl(Url);
                    break;
            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);

            #endregion

            if (IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                //Populate the excel data
                ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
                loginobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
            }
            else
            {
                Registration obj = new Registration();
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

