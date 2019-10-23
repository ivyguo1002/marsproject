using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace MarsFramework
{
    internal class ProfileSkills
    {
        #region  Initialize Web Elements 
        //Click on Skills tab
        IWebElement SkillsTab => Driver.FindElement(By.XPath("//a[text()='Skills']"));

        //Click on Add new to add new skill
        IWebElement AddNewSkillBtn => Driver.FindElement(By.XPath("//th[text()='Skill']//following-sibling::th[@class='right aligned']/div"));

        //Enter the Skill on text box
        IWebElement AddSkillText => Driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

        //Click on skill level dropdown
        IWebElement ChooseSkilllevel => Driver.FindElement(By.XPath("//select[@name='level']"));

        //Add Skill
        IWebElement AddSkillBtn => Driver.FindElement(By.XPath("//input[@value='Add']"));

        //Edit Skill Text
        IWebElement EditSkillText => Driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

        //Edit Skill Level
        IWebElement EditSkillLevel => Driver.FindElement(By.XPath("//select[@name='level']"));

        //Click on Update button
        IWebElement UpdateSkillBtn => Driver.FindElement(By.XPath("//input[@value='Update']"));

        #endregion

        #region Profile->Skills
        internal void ClickSkillsTab()
        {
            SkillsTab.Click();
        }
        internal void AddNewSkill(string skillName, string skillLevel)
        {
            //Add New Skill
            AddNewSkillBtn.Click();
            AddSkillText.SendKeys(skillName);
            new SelectElement(ChooseSkilllevel).SelectByText(skillLevel);
            AddSkillBtn.Click();
        }

        internal void EditSkill(string skillName, string skillLevel,string editedSkillName)
        {
            //Click edit button 
            Driver.FindElement(By.XPath("//td[text()='" + skillName + "']//following-sibling::td[@class='right aligned']//i[@class='outline write icon']")).Click();

            //Update skill
            EditSkillText.Clear();
            EditSkillText.SendKeys(editedSkillName);
            new SelectElement(EditSkillLevel).SelectByText(skillLevel);
            UpdateSkillBtn.Click();
        }

        internal void DeleteSkill(string skillName)
        {
            //Delete the skill
            Driver.FindElement(By.XPath("//td[text()='" + skillName + "']//following-sibling::td[@class = 'right aligned']//i[@class='remove icon']")).Click();
        }

        internal bool ValidateSkills(string name, string level)
        {
            IWebElement table = Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));
            IList<IWebElement> tableRows = table.FindElements(By.TagName("tbody"));
            foreach (var row in tableRows)
            {
                IList<IWebElement> rowTDs = row.FindElements(By.TagName("td"));

                if ((rowTDs[0].Text == name) && (rowTDs[1].Text == level))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}