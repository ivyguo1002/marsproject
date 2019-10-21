using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
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
        internal int SearchService(string title)
        {
            IList<IWebElement> rows = Table.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTDs;
            try
            {
                while (true)
                {
                    for (int i = 0; i < rows.Count; i++)
                    {
                        rowTDs = rows[i].FindElements(By.TagName("td"));
                        if (rowTDs[2].Text == title)
                        {
                            return i;
                        }
                    }
                    GotoNextPage.Click();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Search service failed");
                throw;
            }
        }
        internal void ClickView(string title)
        {
            //Locate row
            int i = SearchService(title);
            Console.WriteLine($"the row number for viewing is {i}");
            //Click View icon
            ViewIcons[i].Click();
        }
        internal void ClickEdit(string title)
        {
            //Locate row
            int i = SearchService(title);
            Console.WriteLine($"the row number for editing is {i}");
            //Click Edit
            EditIcons[i].Click();
        }
        internal void ClickDelete(string title)
        {
            //Locate row
            int i = SearchService(title);
            Console.WriteLine($"the row number for deleting is {i}");

            //Click Delete
            DeleteIcons[i].Click();

        }
        internal void ClickNo()
        {
            //Click Yes
            NoBtn.Click();
        }
        internal void ClickYes()
        {
            YesBtn.Click();
        }
        internal void ClickIsActive(string title)
        {
            //Locate row
            int i = SearchService(title);

            //Click IsActive Checkbox
            IsActiveCheckBox[i].Click();
        }

        internal bool ValidateData(string category, string title, string description, string serviceTypeOption,
            string skillTradeOption)
        {
            //WaitForElement(By.XPath("//div[@id='listing-management-section']/div[2]/div[1]/table/tbody"), 20);

            int i = SearchService(title);
            Console.WriteLine($"the row number is {i}");

            IList<IWebElement> rows = Table.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTDs = rows[i].FindElements(By.TagName("td"));
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

            Console.WriteLine("Actual data \n");
            Console.WriteLine($"{rowTDs[1].Text},{rowTDs[2].Text},{rowTDs[3].Text}, {rowTDs[4].Text},{rowTDs[5].Text}\n");
            Console.WriteLine("Expected data \n");
            Console.WriteLine($"{category},{title},{description},{serviceType},{skillTrade}");

            if (i == -1)
                return false;
            else if (rowTDs[1].Text == category &&
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
