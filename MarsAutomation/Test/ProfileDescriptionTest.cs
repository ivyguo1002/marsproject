using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static MarsFramework.Global.GlobalDefinitions;
using MarsAutomation.Pages;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace MarsAutomation.Test
{
    [TestFixture]
    public class ProfileDescriptionTest : BaseTest
    {
        [Test]
        public void EditDescriptionnValidate()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "Profile->Description");
            string description = ExcelLib.ReadData(2, "Description");

            //Edit Description
            var descriptionObj = new ProfileDescription();
            descriptionObj.EditDescription(description);

            //Validate the message
            string expectedMsg = "Description has been saved successfully";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate if the Description display correctly
            string actualDes = Driver.FindElement(By.XPath("//span[contains(@style,'padding-top: 1em;')]")).Text;
            Assert.AreEqual(description, actualDes, "Description display failed");
        }
    }
}
