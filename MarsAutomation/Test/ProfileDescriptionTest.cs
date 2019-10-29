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

            //Validate message

            //Validate the message
            string expectedMsg = "Description has been saved successfully";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.AreEqual(expectedMsg, actualMsg, "Getting expected message failed");

            //Validate if the Description display correctly
            try
            {
                IWebElement des = Driver.FindElement(By.XPath("//span[text()='" + description + "']"));
                Assert.IsTrue(des.Displayed, "Description display failed");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                test.Log(LogStatus.Fail, "Test ended with fail" + e.Message);
            }
        }
    }
}
