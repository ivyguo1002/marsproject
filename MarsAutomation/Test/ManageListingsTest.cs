using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using static MarsFramework.Global.GlobalDefinitions;
using MarsAutomation.Pages;
using OpenQA.Selenium.Support.UI;

namespace MarsAutomation.Test
{
    [TestFixture]
    public class ManageListingsTest : BaseTest
    {
        [Test]
        public void EditService()
        {
            //Edit the first item in Listings
            var manageListingsInstance = new ManageListings();
            manageListingsInstance.ClickManageListings();
            string firstCategory = Driver.FindElement(By.XPath("//tbody/tr[1]/td[2]")).Text ;
            string firstTitle = Driver.FindElement(By.XPath("//tbody/tr[1]/td[3]")).Text;
            string firstDescription = Driver.FindElement(By.XPath("//tbody/tr[1]/td[4]")).Text;
            string firstServiceType = Driver.FindElement(By.XPath("//tbody/tr[1]/td[5]")).Text;
            string firstSkillTrade = Driver.FindElement(By.XPath("//tbody/tr[1]/td[6]")).Text;
            manageListingsInstance.ClickEdit();

            //Verify if user has been navigated to ServiceListing Page
            string expectedTitle = "ServiceListing";
            string actualTitle = Driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Navigation to ServiceListing Page failed");

            //Verify if the Service details are populated in the ServiceListing Page
            var shareSkillInstance = new ShareSkills();
            Assert.IsTrue(shareSkillInstance.ValidateDetails(firstCategory,firstTitle,firstDescription,
                firstServiceType,firstSkillTrade),"Service details not poplated successfully in edit mode");

            //Edit the service
            #region read data from ShareSkill sheet, row 3
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Read data
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
            #endregion
            //Enter the data
            shareSkillInstance.EditShareSkill(title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate,
                day, startTime, endTime, skillTradeOption, skillExchangeTag, creditAmount, active);
            shareSkillInstance.ClickSave();

            //Verify if the service has been updated successfully in ListManagement Page
            //var manageListingsInstance = new ManageListings();
            manageListingsInstance.ClickManageListings();
            Assert.That(manageListingsInstance.ValidateData(category, title, description, serviceType, skillTradeOption),
                "Editing Service failed");
        }

    }
}
