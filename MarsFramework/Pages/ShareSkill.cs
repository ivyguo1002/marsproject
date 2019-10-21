using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using OpenQA.Selenium.Support.UI;
using AutoIt;
using System.Threading;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        #region Initialize Webelements
        //Click on ShareSkill Button
        IWebElement ShareSkillButton => Driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title in textbox
        IWebElement Title => Driver.FindElement(By.Name("title"));

        //Enter the Description in textbox
        IWebElement Description => Driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        IWebElement CategoryDropDown => Driver.FindElement(By.Name("categoryId"));

        //Click on SubCategory Dropdown
        IWebElement SubCategoryDropDown => Driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        IWebElement Tags => Driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //Select the Service type
        IWebElement ServiceTypeOptions => Driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));

        //Select the Location Type
        IWebElement LocationTypeOptions => Driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Start Date dropdown
        IWebElement StartDateDropDown => Driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        IWebElement EndDateDropDown => Driver.FindElement(By.Name("endDate"));

        //Storing the table of available days
        IWebElement Days => Driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));

        //Storing the starttime
        IWebElement StartTime => Driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on EndTime dropdown
        IWebElement EndTime => Driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Click on Skill Trade option
        IWebElement SkillTradeOptions => Driver.FindElement(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Enter Skill Exchange
        IWebElement SkillExchange => Driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Enter the amount for Credit
        IWebElement CreditAmount => Driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Work Sample Huge Plus Icon
        IWebElement PlusIcon => Driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        //Click on Active/Hidden option
        IWebElement ActiveOptions => Driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Save button
        IWebElement Save => Driver.FindElement(By.XPath("//input[@value='Save']"));

        //Click on Cancel
        IWebElement Cancel => Driver.FindElement(By.XPath("//input[@value='Cancel']"));
        #endregion

        internal void ClickShareSkill()
        {
            //Click on "Share skill" button
            ShareSkillButton.Click();
        }

        internal void EnterShareSkill(string title,string description,string category,string subCategory,string tags,
            string serviceType,string locationType,string startDate,string endDate, string day,string startTime,string endTime,
            string skillTradeOption,string skillExchangeTag,string creditAmount,string active)
        {
            //Input Title
            Title.SendKeys(title);

            //Input Description
            Description.SendKeys(description);

            //Select Category
            new SelectElement(CategoryDropDown).SelectByText(category);

            //Select Sub-Category
            new SelectElement(SubCategoryDropDown).SelectByText(subCategory);

            //Add tag
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Enter);

            //Select ServiceType
            ServiceTypeOptions.FindElement(By.XPath($"//label[text()='{serviceType}']//preceding-sibling::input")).Click();
            

            //Select LocationType
            LocationTypeOptions.FindElement(By.XPath($"//label[text()='{locationType}']//preceding-sibling::input")).Click();

            //Enter Startdate
            StartDateDropDown.SendKeys(startDate);

            //Enter Enddate
            EndDateDropDown.SendKeys(endDate);

            //Select Days
            Days.FindElement(By.XPath($"//label[text()='{day}']//preceding-sibling::input")).Click();

            //Enter Starttime
            StartTime.SendKeys(startTime);

            //Enter Endtime
            EndTime.SendKeys(endTime);

            //Select Skilltrade option
            SkillTradeOptions.FindElement(By.XPath($"//label[text()='{skillTradeOption}']//preceding-sibling::input")).Click();

            //Config Skilltrade according to options
            switch (skillTradeOption)
            {
                case "Skill-exchange":
                    SkillExchange.SendKeys(skillExchangeTag);
                    SkillExchange.SendKeys(Keys.Enter);
                    break;
                case "Credit":
                    CreditAmount.SendKeys(creditAmount);
                    break;
            }

            //Upload Work Sample
            PlusIcon.Click();
            AutoItX.WinWaitActive("Open");
            AutoItX.ControlFocus("Open", "", "Edit1");
            AutoItX.ControlSetText("Open", "", "Edit1", WorkSamplePath);
            AutoItX.ControlClick("Open", "", "Button1");
            
            //Select Active Option
            ActiveOptions.FindElement(By.XPath($"//label[text()='{active}']//preceding-sibling::input")).Click();
        }

        internal void ClickSave()
        {
            //Click on Save button
            Save.Click();
        }

        internal void ClickCancel()
        {
            //Click on Cancel button
            Cancel.Click();
        }

    }
}
