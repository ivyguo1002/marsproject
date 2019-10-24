using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    class SearchSkills
    {
        #region identify elements
        IWebElement SearchIcon => Driver.FindElement(By.XPath("//i[@class='search link icon']"));
        IWebElement AllCategory => Driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]"));

        IWebElement SearchSkillsBox => Driver.FindElement(By.XPath("//div[@class='four wide column']//input[@placeholder='Search skills']"));
        IWebElement SearchLink => Driver.FindElement(By.XPath("//div[@class='four wide column']//i[@class='search link icon']"));
        IWebElement SearchUser => Driver.FindElement(By.XPath("//input[@placeholder='Search user']"));

        IWebElement OnlineBtn => Driver.FindElement(By.XPath("//button[contains(text(),'Online')]"));
        IWebElement OnsiteBtn => Driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]"));
        IWebElement ShowAllBtn => Driver.FindElement(By.XPath("//button[contains(text(),'ShowAll')]"));
        IList <IWebElement> SellerInfo => Driver.FindElements(By.XPath("//a[@class='seller-info']"));
        IList <IWebElement> ServiceInfo => Driver.FindElements(By.XPath("//a[@class='service-info']/p"));
        #endregion

        internal void ClickSearch()
        {
            SearchIcon.Click();
        }
        internal void ClickCategory(string category, string subcategory)
        {
            AllCategory.Click();
            Driver.FindElement(By.XPath("//a[contains(text(),'" + category + "')]")).Click();
            Driver.FindElement(By.XPath("//a[contains(text(),'"+subcategory+"')]")).Click();
        }
        internal void InputSearchSkills(string searchSkill)
        {
            SearchSkillsBox.SendKeys(searchSkill);
            SearchLink.Click();
        }

        internal void InputSearchUser(string username)
        {
            SearchUser.SendKeys(username);
            SearchUser.SendKeys(Keys.Enter);
        }

        internal void FilterbyOnline()
        {
            OnlineBtn.Click();
        }

        internal void FilterbyOnsite()
        {
            OnsiteBtn.Click();
        }

        internal void FilterbyShowAll()
        {
            ShowAllBtn.Click();
        }

        //ServiceDetails feature not completed
        //only username and title can be validated
        internal Boolean ValidateResults(string username, string title)
        {
            if ((SellerInfo[0].Text == username) && (ServiceInfo[0].Text == title))
                return true;
            else
                return false;
        }

        internal Boolean ValidateTitle(string title)
        {
            for (int i = 0; i < ServiceInfo.Count(); i++)
            {
                if (!ServiceInfo[i].Text.Contains(title))
                    return false;
            }

            return true;
        }

        internal Boolean ValidateUser(string username)
        {
            for (int i = 0; i < SellerInfo.Count(); i++)
            {
                if (!(SellerInfo[i].Text==username))
                    return false;
            }

            return true;
        }
    }
}
