using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    class SignIn
    {
        #region  Initialize Web Elements 
        //Finding the Sign Link

        IWebElement SignIntab => Driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));

        // Finding the Email Field
        IWebElement Email => Driver.FindElement(By.Name("email"));

        //Finding the Password Field
        IWebElement Password => Driver.FindElement(By.Name("password"));

        //Finding the Login Button
        IWebElement LoginBtn => Driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        #endregion

        internal void LoginSteps()
        {
            //Populate the excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Navigate to the Login page
            Driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));

            //Click on SignIn tab
            SignIntab.Click();

            //Input Email Address
            Email.SendKeys(ExcelLib.ReadData(2,"Username"));

            //Input Password
            Password.SendKeys(ExcelLib.ReadData(2,"Password"));

            //Click on Login Button
            LoginBtn.Click();
        }
    }
}