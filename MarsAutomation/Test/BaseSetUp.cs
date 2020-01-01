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
//    [SetUpFixture]
//    public class BaseSetUp: Base
//    {
//        [OneTimeSetUp]
//        public void RunBeforeAnyTests()
//        {
//            // Executes once before the test run. (Optional)
//            switch (Browser)
//            {

//                case 1:
//                    Driver = new FirefoxDriver();
//                    break;
//                case 2:
//                    Driver = new ChromeDriver();
//                    Driver.Manage().Window.Maximize();
//                    Driver.Navigate().GoToUrl(Url);
//                    break;
//            }


//            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
//            extent.LoadConfig(ReportXMLPath);

//            if (IsLogin == "true")
//            {
//                SignIn loginobj = new SignIn();
//                //Populate the excel data
//                ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
//                loginobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
//            }
//            else
//            {
//                Registration obj = new Registration();
//                obj.Register();
//            }

//            //Set Implicit Wait
//            Wait(20);
//        }
//    [OneTimeTearDown]
//    public void RunAfterAnyTests()
//    {
//            // Executes once after the test run. (Optional)

//            Driver.Close();
//            Driver.Quit();
//        }
//}
}
