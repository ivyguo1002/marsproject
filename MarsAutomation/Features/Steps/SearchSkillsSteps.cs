using MarsAutomation.Pages;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using System.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace MarsAutomation.Features.Steps
{
    [Binding]
    public class SearchSkillsSteps
    {
        private ScenarioContext _scenarioContext;
        public SearchSkillsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I click search icon on Profile Page")]
        public void GivenIClickSearchIconOnProfilePage()
        {
            //Search by category and subcategory
            var searchSkillsObj = new SearchSkills();
            _scenarioContext["searchSkillsObj"] = searchSkillsObj;
            searchSkillsObj.ClickSearch();
        }
        
        [Given(@"I input search skills")]
        public void GivenIInputSearchSkills()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "SearchSkills");
            string searchSkill = ExcelLib.ReadData(3, "SearchSkills");

            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            _scenarioContext["searchSkill"] = searchSkill;
            searchSkillsObj.InputSearchSkills(searchSkill);
        }
        
        [When(@"I click category and subcategory")]
        public void WhenIClickCategoryAndSubcategory()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "SearchSkills");
            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(2, "SubCategory");

            _scenarioContext["category"] = category;
            _scenarioContext["subcategory"] = subcategory;
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            searchSkillsObj.ClickCategory(category, subcategory);

        }
        
        [When(@"I choose Filter by Online")]
        public void WhenIChooseFilterByOnline()
        {
            //Filter by Online
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            searchSkillsObj.FilterbyOnline();
        }
        
        [When(@"I choose Filter by OnSite")]
        public void WhenIChooseFilterByOnSite()
        {
            //Filter by Onsite
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            searchSkillsObj.FilterbyOnsite();
        }
        
        [When(@"I choose Filter by ShowAll")]
        public void WhenIChooseFilterByShowAll()
        {
            //Filter by showall
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            searchSkillsObj.FilterbyShowAll();
        }
        
        [Then(@"The search results should be updated by category and subcategory")]
        public void ThenTheSearchResultsShouldBeUpdatedByCategoryAndSubcategory()
        {
            //Validate the result in ServiceDetails Page
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);

                var category = (string)_scenarioContext["category"];
                var subcategory = (string)_scenarioContext["subcategory"];
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(category, serviceDetailsObj.Category.Text);
                    Assert.AreEqual(subcategory, serviceDetailsObj.SubCategory.Text);
                });

                Assert.AreEqual("Online", serviceDetailsObj.LocationType.Text);
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }
        }
        
        [Then(@"The search results should be filtered by Online")]
        public void ThenTheSearchResultsShouldBeFilteredByOnline()
        {
            //Validate the result in ServiceDetails Page
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);
                Assert.AreEqual("Online", serviceDetailsObj.LocationType.Text);
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }
        }
        
        [Then(@"The search results should be filtered by OnSite")]
        public void ThenTheSearchResultsShouldBeFilteredByOnSite()
        {
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];

            //Validate the result in ServiceDetails Pag
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);
                Assert.AreEqual("On-Site", serviceDetailsObj.LocationType.Text, "Filter by Onsite failed");
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }
        }
        
        [Then(@"The search results should be filtered by ShowAll")]
        public void ThenTheSearchResultsShouldBeFilteredByShowAll()
        {
            var searchSkillsObj = (SearchSkills)_scenarioContext["searchSkillsObj"];
            var searchSkill =(string) _scenarioContext["searchSkill"];
            Assert.IsTrue(searchSkillsObj.ValidateTitle(searchSkill));
        }
    }
}
