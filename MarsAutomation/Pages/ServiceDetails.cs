using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsAutomation.Pages
{
    class ServiceDetails
    {
        #region identify elements
        internal IWebElement Category => Driver.FindElement(By.XPath("//div[text()='Category']//following-sibling::div"));
        internal IWebElement SubCategory => Driver.FindElement(By.XPath("//div[text()='Subcategory']//following-sibling::div"));
        internal IWebElement LocationType => Driver.FindElement(By.XPath("//div[text()='Location Type']//following-sibling::div"));
        #endregion

    }
}
