using MarsFramework.Global;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using MarsAutomation.Pages;
using NUnit.Framework;
using static MarsFramework.Global.Base;

namespace MarsAutomation.Features.Steps
{
    [Binding]
    public class SignInTestSteps
    {
        [Given(@"I Click on the Sign In tab, input valid email address and password and Click on Login button")]
        public void WhenIClickOnTheSignInTabInputValidEmailAddressAndPasswordAndClickOnLoginButton()
        {
            SignIn loginobj = new SignIn();
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            loginobj.LoginSteps(ExcelLib.ReadData(2, "Username"), ExcelLib.ReadData(2, "Password"));
        }

        [Given(@"I Click on the Sign In tab, input invalid email address and password and Click on Login button")]
        public void WhenIClickOnTheSignInTabInputInvalidEmailAddressAndPasswordAndClickOnLoginButton()
        {
            var loginObj = new SignIn();
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");
            loginObj.LoginSteps(ExcelLib.ReadData(3, "Username"), ExcelLib.ReadData(3, "Password"));
        }

        [Then(@"I should be able to sign in successfully")]
        public void ThenIShouldBeAbleToSignInSuccessfully()
        {
            //Verify if signout button is enabled
            IWebElement SignOut = Driver.FindElement(By.XPath("//button[text()='Sign Out']"));
            Assert.IsTrue(SignOut.Enabled, "SignOut button isn't enabled");
            //Verify if user is navigated to Profile Page
            string expectedTitle = "Profile";
            string actualTitle = Driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle, "SignIn Failed");
        }

        [Then(@"I should not be able to sign in successfully")]
        public void ThenIShouldNotBeAbleToSignInSuccessfully()
        {
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
