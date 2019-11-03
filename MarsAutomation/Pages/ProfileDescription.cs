using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsAutomation.Pages
{
    class ProfileDescription
    {
        #region identify elements
        //Description Icon
        IWebElement DescriptionIcon => Driver.FindElement(By.XPath("//h3[text()='Description']//i[@class='outline write icon']"));

        //Description Text 
        IWebElement DescriptionTextArea => Driver.FindElement(By.Name("value"));

        //Save button
        IWebElement SaveBtn => Driver.FindElement(By.XPath("(//button[text()='Save'])[2]"));

        #endregion
        //Edit Description
        internal void EditDescription(string descriptionText)
        {
            //Click Edit Description icon
            DescriptionIcon.Click();
            Thread.Sleep(3000);

            //Enter Description and Click Save
            DescriptionTextArea.SendKeys("");
            DescriptionTextArea.Clear();
            DescriptionTextArea.SendKeys(descriptionText);
            SaveBtn.Click();
        }
    }
}
