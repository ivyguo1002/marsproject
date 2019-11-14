using MarsAutomation.Pages;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsAutomation.Features.Steps
{
    [Binding]
    public class ProfileSkillsSteps
    {
        private ScenarioContext _scenarioContext;
        public ProfileSkillsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I Click on Skills tab")]
        public void GivenIClickOnSkillsTab()
        {
            var skillsObj = new ProfileSkills();
            _scenarioContext["skillsObj"] = skillsObj;
            skillsObj.ClickSkillsTab();
        }
        
        [When(@"I Add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(2, "SkillName");
            string skillLevel = ExcelLib.ReadData(2, "SkillLevel");
            _scenarioContext["addskillname"] = skillName;
            _scenarioContext["addskilllevel"] = skillLevel;

            //Add a new skill
            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            skillsObj.AddNewSkill(skillName, skillLevel);
        }
        
        [When(@"I Edit a skill")]
        public void WhenIEditASkill()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(3, "SkillName");
            string skillLevel = ExcelLib.ReadData(3, "SkillLevel");
            string editedSkillName = ExcelLib.ReadData(3, "SkillNameUpdate");

            _scenarioContext["editskillname"] = editedSkillName;
            _scenarioContext["editskilllevel"] = skillLevel;
            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            skillsObj.EditSkill(skillName, skillLevel, editedSkillName);

        }
        
        [When(@"I delete a skill")]
        public void WhenIDeleteASkill()
        {
            //read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(4, "SkillName");
            string skillLevel = ExcelLib.ReadData(4, "SkillLevel");

            _scenarioContext["deleteskillname"] = skillName;
            _scenarioContext["deleteskilllevel"] = skillLevel;

            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            skillsObj.DeleteSkill(skillName);

        }
        
        [Then(@"The skill should be added successfully")]
        public void ThenTheSkillShouldBeAddedSuccessfully()
        {
            //Validate the message
            string expectedMsg = _scenarioContext["addskillname"] + " has been added to your skills";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            Assert.IsTrue(skillsObj.ValidateSkills((string)_scenarioContext["addskillname"],(string)_scenarioContext["addskilllevel"]), "Add a new skill failed");

        }
        
        [Then(@"The skill should be updated successfully")]
        public void ThenTheSkillShouldBeUpdatedSuccessfully()
        {
            //Validate the message
            var editedSkillName = (string) _scenarioContext["editskillname"];
            var skillLevel = (string)_scenarioContext["editskilllevel"];
            string expectedMsg = editedSkillName + " has been updated to your skills";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            Assert.IsTrue(skillsObj.ValidateSkills(editedSkillName, skillLevel), "Edit skill failed");
        }
        
        [Then(@"The skill should be deleted successfully")]
        public void ThenTheSkillShouldBeDeletedSuccessfully()
        {
            var skillName = (string) _scenarioContext["deleteskillname"];
            var skillLevel = (string)_scenarioContext["deleteskilllevel"];
            //Validate the message
            string expectedMsg = skillName + " has been deleted";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            var skillsObj = (ProfileSkills)_scenarioContext["skillsObj"];
            Assert.IsFalse(skillsObj.ValidateSkills(skillName, skillLevel), "Delete skill failed");
        }
    }
}
