using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    class SignUp
    {
        #region  Initialize Web Elements 
        //Finding the Join 
        IWebElement Join => Driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));

        //Identify FirstName Textbox
        IWebElement FirstName => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[1]/input"));

        //Identify LastName Textbox
        IWebElement LastName => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[2]/input"));

        //Identify Email Textbox
        IWebElement Email => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[3]/input"));

        //Identify Password Textbox
        IWebElement Password => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[4]/input"));

        //Identify Confirm Password Textbox}
        IWebElement ConfirmPassword => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[5]/input"));

        //Identify Term and Conditions Checkbox
        IWebElement Checkbox => Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/form/div[6]/div/div/input"));

        //Identify join button
        IWebElement JoinBtn => Driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        #endregion

        internal void Register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();


        }
    }
}
