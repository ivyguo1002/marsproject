using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using MarsAutomation.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace MarsAutomation.Features.Steps
{
    [Binding]
    public class Hooks : Base
    {
        #region setup and tear down
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext,FeatureContext featureContext)
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
            test = extent.StartTest(scenarioContext.ScenarioInfo.Title);
            #endregion

            if (featureContext.FeatureInfo.Title != "SignIn")
            {
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
            }
            //Set Implicit Wait
            Wait(20);
        }


        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            //Get test restult
            var status = scenarioContext.TestError;

            // Screenshot
            string screenShotPath = SaveScreenShotClass.SaveScreenshot(Driver, TestContext.CurrentContext.Test.Name);

            // Write log to report
            LogStatus logstatus;
            if (status != null)
            {
                logstatus = LogStatus.Fail;
                test.Log(logstatus, "Test ended with " + logstatus + "–" + scenarioContext.TestError.Message);
                test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
            }
            else
            {
                logstatus = LogStatus.Pass;
                test.Log(logstatus, "Test ended with " + logstatus);
                test.Log(LogStatus.Info, "Snapshot below:" + test.AddScreenCapture(screenShotPath));
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
