using MarsAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;

namespace MarsAutomation
{
    [Binding]
    public class ManageListingsSteps
    {
        private ScenarioContext _scenarioContext;
        public ManageListingsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I click Edit button on the first item in Managelistings Page")]
        public void GivenIClickEditButtonOnTheFirstItemInManagelistingsPage()
        {
            //Edit the first item in Listings
            var manageListingsInstance = new ManageListings();
            _scenarioContext["manageListingsInstance"] = manageListingsInstance;
            manageListingsInstance.ClickManageListings();
            _scenarioContext["firstCategory"] = Driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Text;
            _scenarioContext["firstTitle"] = Driver.FindElement(By.XPath("//tbody/tr[1]/td[3]")).Text;
            _scenarioContext["firstDescription"] = Driver.FindElement(By.XPath("//tbody/tr[1]/td[4]")).Text;
            _scenarioContext["firstServiceType"] = Driver.FindElement(By.XPath("//tbody/tr[1]/td[5]")).Text;
            _scenarioContext["firstSkillTrade"] = Driver.FindElement(By.XPath("//tbody/tr[1]/td[6]")).Text;
            manageListingsInstance.ClickEdit();
        }
        
        [When(@"I edit and update the service")]
        public void WhenIEditAndUpdateTheService()
        {
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Read data
            #region read data from ShareSkill sheet, row 3
            string title = ExcelLib.ReadData(3, "Title");
            string description = ExcelLib.ReadData(3, "Description");
            string category = ExcelLib.ReadData(3, "Category");
            string subCategory = ExcelLib.ReadData(3, "SubCategory");
            string tags = ExcelLib.ReadData(3, "Tags");
            string serviceType = ExcelLib.ReadData(3, "ServiceType");
            string locationType = ExcelLib.ReadData(3, "LocationType");
            string startDate = ExcelLib.ReadData(3, "Startdate");
            string endDate = ExcelLib.ReadData(3, "Enddate");
            string day = ExcelLib.ReadData(3, "Selectday");
            string startTime = ExcelLib.ReadData(3, "Starttime");
            string endTime = ExcelLib.ReadData(3, "Endtime");
            string skillTradeOption = ExcelLib.ReadData(3, "SkillTrade");
            string skillExchangeTag = ExcelLib.ReadData(3, "Skill-exchange");
            string creditAmount = ExcelLib.ReadData(3, "Credit");
            string active = ExcelLib.ReadData(3, "Active");

            _scenarioContext["title"] = title;
            _scenarioContext["description"] = description;
            _scenarioContext["category"] = category;
            _scenarioContext["subCategory"] = subCategory;
            _scenarioContext["tags"] = tags;
            _scenarioContext["serviceType"] = serviceType;
            _scenarioContext["locationType"] = locationType;
            _scenarioContext["startDate"] = startDate;
            _scenarioContext["endDate"] = endDate;
            _scenarioContext["day"] = day;
            _scenarioContext["startTime"] = startTime;
            _scenarioContext["endTime"] = endTime;
            _scenarioContext["skillTradeOption"] = skillTradeOption;
            _scenarioContext["skillExchangeTag"] = skillExchangeTag;
            _scenarioContext["creditAmount"] = creditAmount;
            _scenarioContext["active"] = active;

            #endregion
            //Enter the data
            var shareSkillInstance = (ShareSkills)_scenarioContext["shareSkillInstance"];
            shareSkillInstance.EditShareSkill(title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate,
                day, startTime, endTime, skillTradeOption, skillExchangeTag, creditAmount, active);
            shareSkillInstance.ClickSave();

        }

        [Then(@"I should be navigated to ServiceListing Page")]
        public void ThenIShouldBeNavigatedToServiceListingPage()
        {
            //Verify if user has been navigated to ServiceListing Page
            string expectedTitle = "ServiceListing";
            string actualTitle = Driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Navigation to ServiceListing Page failed");
        }
        
        [Then(@"The Service details should be populated in the ServiceListing Page")]
        public void ThenTheServiceDetailsShouldBePopulatedInTheServiceListingPage()
        {
            //Verify if the Service details are populated in the ServiceListing Page
            var firstCategory = (string)_scenarioContext["firstCategory"];
            var firstTitle = (string)_scenarioContext["firstTitle"];
            var firstDescription = (string)_scenarioContext["firstDescription"];
            var firstServiceType = (string)_scenarioContext["firstServiceType"];
            var firstSkillTrade = (string)_scenarioContext["firstSkillTrade"];

            var shareSkillInstance = new ShareSkills();
            _scenarioContext["shareSkillInstance"] = shareSkillInstance;
            Assert.IsTrue(shareSkillInstance.ValidateDetails(firstCategory, firstTitle, firstDescription,
                firstServiceType, firstSkillTrade), "Service details not poplated successfully in edit mode");
        }
        
        [Then(@"The service should be updated successfully")]
        public void ThenTheServiceShouldBeUpdatedSuccessfully()
        {
            //Verify if the service has been updated successfully in ListManagement Page
            var manageListingsInstance =(ManageListings) _scenarioContext["manageListingsInstance"];
            var title = (string)_scenarioContext["title"];
            var description = (string)_scenarioContext["description"];
            var category = (string)_scenarioContext["category"];
            var serviceType = (string)_scenarioContext["serviceType"];
            var skillTradeOption = (string)_scenarioContext["skillTradeOption"];

            manageListingsInstance.ClickManageListings();
            Assert.That(manageListingsInstance.ValidateData(category, title, description, serviceType, skillTradeOption),
                "Editing Service failed");
        }
    }
}
