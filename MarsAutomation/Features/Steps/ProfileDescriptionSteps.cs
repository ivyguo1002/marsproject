using MarsAutomation.Features.Steps;
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
    public class ProfileDescriptionSteps
    {
        private ScenarioContext _scenarioContext;
        public ProfileDescriptionSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I edit description on Profile Page and click save")]
        public void GivenIEditDescriptionOnProfilePageAndClickSave()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "Profile->Description");
            var description = ExcelLib.ReadData(2, "Description");
            _scenarioContext["description"] = description;

            //Edit Description
            var descriptionObj = new ProfileDescription();
            descriptionObj.EditDescription(description);
        }

        [Then(@"The profile description should update and display correctly")]
        public void ThenTheProfileDescriptionShouldUpdateAndDisplayCorrectly()
        {
            //Validate the message
            string expectedMsg = "Description has been saved successfully";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate if the Description display correctly
            string actualDes = Driver.FindElement(By.XPath("//span[contains(@style,'padding-top: 1em;')]")).Text;

            var description = (string)_scenarioContext["description"];
            Assert.AreEqual(description, actualDes, "Description display failed");
        }
    }
}
