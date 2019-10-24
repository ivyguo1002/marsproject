using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Test
{
    [TestFixture]
    public class SignInTest : Global.Base
    {
        public override void Inititalize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);

            #endregion

            //Set Implicit Wait
            Wait(20);
        }

        [Test]
        public void SignInwithValidCredential()
        {
            SignIn loginobj = new SignIn();
            loginobj.LoginSteps();
            
            //Verify if signout button is enabled
            IWebElement SignOut = Driver.FindElement(By.XPath("//button[text()='Sign Out']"));
            Assert.IsTrue(SignOut.Enabled, "SignOut button isn't enabled");
            //Verify if user is navigated to Profile Page
            string expectedTitle = "Profile";
            string actualTitle = Driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle, "SignIn Failed");
        }

        [Test]
        public void SignInwithInvalidCredential()
        {
            var loginObj = new SignIn();
            loginObj.LoginFail();

            //Verify if user is able to see "Send Verification Email" button
            IWebElement SendEmailBtn = Driver.FindElement(By.XPath("//button[@id='submit-btn']"));
            Assert.IsTrue(SendEmailBtn.Enabled, "User failed to view Send Vefication Email button");
            //Verify if user receives error message
            string expectedMsg = "Confirm your email";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");
        }
    }
}
