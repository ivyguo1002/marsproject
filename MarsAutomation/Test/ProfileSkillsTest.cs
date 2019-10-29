using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;
using MarsAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsAutomation.Test
{
    [TestFixture]
    public class ProfileSkillsTest : BaseTest
    {
        [Test, Order(1)]
        public void AddSkillnValidate()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(2, "SkillName");
            string skillLevel = ExcelLib.ReadData(2, "SkillLevel");

            //Add a new skill
            ProfileSkills skillsobj = new ProfileSkills();
            skillsobj.ClickSkillsTab();
            skillsobj.AddNewSkill(skillName, skillLevel);

            //Validate the message
            string expectedMsg = skillName + " has been added to your skills";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            Assert.IsTrue(skillsobj.ValidateSkills(skillName, skillLevel), "Add a new skill failed");

        }

        [Test, Order(2)]
        public void EditSkillnValidate()
        {
            //Read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(3, "SkillName");
            string skillLevel = ExcelLib.ReadData(3, "SkillLevel");
            string editedSkillName = ExcelLib.ReadData(3, "SkillNameUpdate");

            //Edit skill
            ProfileSkills skillsobj = new ProfileSkills();
            skillsobj.ClickSkillsTab();
            skillsobj.EditSkill(skillName, skillLevel, editedSkillName);

            //Validate the message
            string expectedMsg = editedSkillName + " has been updated to your skills";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            Assert.IsTrue(skillsobj.ValidateSkills(editedSkillName, skillLevel), "Edit skill failed");
        }

        [Test, Order(3)]
        public void DeleteSkillnValidate()
        {
            //read data from excel data file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile->Skills");
            string skillName = ExcelLib.ReadData(4, "SkillName");
            string skillLevel = ExcelLib.ReadData(4, "SkillLevel");

            //Delete skill
            ProfileSkills skillsObj = new ProfileSkills();
            skillsObj.ClickSkillsTab();
            skillsObj.DeleteSkill(skillName);

            //Validate the message
            string expectedMsg = skillName + " has been deleted";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate the skill
            Assert.IsFalse(skillsObj.ValidateSkills(skillName, skillLevel), "Delete skill failed");
        }
    }
}
