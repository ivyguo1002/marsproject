using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;
using System;

namespace MarsAutomation.Pages
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

        internal void LoginSteps(string username, string password)
        {

            //Click on SignIn tab
            SignIntab.Click();

            //Input Email Address
            Email.SendKeys(username);

            //Input Password
            Password.SendKeys(password);

            //Click on Login Button
            LoginBtn.Click();
        }
    }
}
