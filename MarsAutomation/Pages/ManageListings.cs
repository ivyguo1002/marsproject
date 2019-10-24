using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsAutomation.Pages
{
    class ManageListings
    {
        #region Initialize WebElements
        //Click on Manage Listings Link
        IWebElement ManageListingsLink => Driver.FindElement(By.LinkText("Manage Listings"));

        //Listing Table
        IWebElement Table => Driver.FindElement(By.XPath("//div[@id='listing-management-section']/div[2]/div[1]/table/tbody"));

        //Go to next page
        IWebElement GotoNextPage => Driver.FindElement(By.XPath("//button[contains(text(),'>')]"));

        //View the listing
        IList<IWebElement> ViewIcons => Driver.FindElements(By.XPath("(//i[@class='eye icon'])"));

        //Edit the listing
        IList<IWebElement> EditIcons => Driver.FindElements(By.XPath("//i[@class='outline write icon']"));

        //Delete the listing
        IList<IWebElement> DeleteIcons => Driver.FindElements(By.XPath("//i[@class='remove icon']"));

        //Yes button
        IWebElement YesBtn => Driver.FindElement(By.XPath("//button[text()='Yes']"));

        //No button
        IWebElement NoBtn => Driver.FindElement(By.XPath("//button[text()='No']"));


        //Click on IsActive
        IList<IWebElement> IsActiveCheckBox => Driver.FindElements(By.XPath("//input[@name='isActive']"));

        #endregion

        internal void ClickManageListings()
        {
            //Click ManageListings link
            ManageListingsLink.Click();

        }
        internal void ClickEdit()
        {
            //Edit the first item from listings
            EditIcons[0].Click();
        }
        internal bool ValidateData(string category, string title, string description, string serviceTypeOption,
            string skillTradeOption)
        {
            IList<IWebElement> rows = Table.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTDs = rows[0].FindElements(By.TagName("td"));
            string skillTrade;
            string serviceType;

            if (skillTradeOption == "Skill-exchange")
                skillTrade = "On";
            else
                skillTrade = "Off";

            if (serviceTypeOption == "Hourly basis service")
                serviceType = "Hourly";
            else
                serviceType = "One-off";

            if (rowTDs[1].Text == category &&
                rowTDs[2].Text == title &&
                rowTDs[3].Text == description &&
                rowTDs[4].Text == serviceType &&
                rowTDs[5].Text == skillTrade
                )
                return true;
            else
                return false;

        }
    }
}
