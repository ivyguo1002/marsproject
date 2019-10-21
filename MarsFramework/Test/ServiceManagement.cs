using NUnit.Framework;
using MarsFramework.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using System;
using RelevantCodes.ExtentReports;

namespace MarsFramework
{
    [TestFixture]
    [Category("Sprint1")]
    public class ServiceManagement : Global.Base
    {
        [Test, Property("TestCaseID", "ShareSkill_TC_012_01, ManageListings_TC_003_01"), Order(1)]
        //Failed, uploading work sample not working properly
        public void CreateService()
        {
            #region read data from ShareSkill sheet, row 2
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Read data
            string title = ExcelLib.ReadData(2, "Title");
            string description = ExcelLib.ReadData(2, "Description");
            string category = ExcelLib.ReadData(2, "Category");
            string subCategory = ExcelLib.ReadData(2, "SubCategory");
            string tags = ExcelLib.ReadData(2, "Tags");
            string serviceType = ExcelLib.ReadData(2, "ServiceType");
            string locationType = ExcelLib.ReadData(2, "LocationType");
            string startDate = ExcelLib.ReadData(2, "Startdate");
            string endDate = ExcelLib.ReadData(2, "Enddate");
            string day = ExcelLib.ReadData(2, "Selectday");
            string startTime = ExcelLib.ReadData(2, "Starttime");
            string endTime = ExcelLib.ReadData(2, "Endtime");
            string skillTradeOption = ExcelLib.ReadData(2, "SkillTrade");
            string skillExchangeTag = ExcelLib.ReadData(2, "Skill-exchange");
            string creditAmount = ExcelLib.ReadData(2, "Credit");
            string active = ExcelLib.ReadData(2, "Active");
            #endregion

            //Create a new service
            var shareSkillInstance = new ShareSkill();
            shareSkillInstance.ClickShareSkill();
            shareSkillInstance.EnterShareSkill(title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate,
                day, startTime, endTime, skillTradeOption, skillExchangeTag, creditAmount, active);
            shareSkillInstance.ClickSave();

            //Verify if user get the message correctly
            string expectedMsg = "Service Listing Added successfully";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;
            Assert.That(actualMsg, Is.EqualTo(expectedMsg), "Getting expected message failed");

            //Verify if user been navigated to ListManagement Page
            string expectedTitle = "ListingManagement";
            string actualTitle = Driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Navigation to ListManagement Page failed");

            //Verify if the created service is listed in ListManagement Page successfully
            var manageListingsInstance = new ManageListings();
            Assert.That(manageListingsInstance.ValidateData(category, title, description, serviceType, skillTradeOption),
                "Creating service failed");

        }

        [Test, Property("TestCaseID", "ManageListings_TC_005_01"), Order(2)]
        //Passed, ServiceDetails page not function well
        public void ViewListings()
        {
            //Populate the Excel Sheet
            ExcelLib.PopulateInCollection(ExcelPath, "ManageListings");
            string title = ExcelLib.ReadData(2, "Title");

            //Search the service in Listings and click view
            var manageListingsInstance = new ManageListings();
            manageListingsInstance.ClickManageListings();
            manageListingsInstance.ClickView(title);

            //Verify if user is able to click view and view the service details successfully
            string expectedTitle = "Service Detail";
            string actualTitle = Driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Open Service Detail page failed");
        }

        [Test, Property("TestCaseID", "ManageListing_TC_006_02"), Order(3)]
        //Failed, Edit not working properly
        public void EditService()
        {
            //Populate the Excel Sheet
            ExcelLib.PopulateInCollection(ExcelPath, "ManageListings");
            string title = ExcelLib.ReadData(2, "Title");

            //Search from listing and click edit
            var managementListingsInstance = new ManageListings();
            managementListingsInstance.ClickManageListings();
            managementListingsInstance.ClickEdit(title);

            //Verify if user has been navigated to ServiceListing Page
            string expectedTitle = "ServiceListing";
            string actualTitle = Driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Navigation to ServiceListing Page failed");

            //Edit the service
            #region read data from ShareSkill sheet, row 3
            //Populate the excel data
            ExcelLib.PopulateInCollection(ExcelPath, "ShareSkill");

            //Read data
            //Keep title same
            //string title = ExcelLib.ReadData(3, "Title");
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
            var shareSkillInstance = new ShareSkill();
            //shareSkillInstance.ClickShareSkill();
            shareSkillInstance.EnterShareSkill(title, description, category, subCategory, tags, serviceType, locationType, startDate, endDate,
                day, startTime, endTime, skillTradeOption, skillExchangeTag, creditAmount, active);
            shareSkillInstance.ClickSave();

            //Verify if the service has been updated successfully in ListManagement Page
            var manageListingsInstance = new ManageListings();
            manageListingsInstance.ClickManageListings();
            Assert.That(manageListingsInstance.ValidateData(category, title, description, serviceType, skillTradeOption),
                "Editing Service failed");
        }

        [Test, Property("TestCaseID", "ManageListings_TC_007_03"), Order(4)]
        //Passed
        public void DeleteService()
        {
            //Populate the Excel Sheet
            ExcelLib.PopulateInCollection(ExcelPath, "ManageListings");
            string title = ExcelLib.ReadData(2, "Title");
            Console.WriteLine($"the title for deleting is {title}");

            //Search service and Delete
            var managementListingsInstance = new ManageListings();
            managementListingsInstance.ClickManageListings();
            managementListingsInstance.ClickDelete(title);
            managementListingsInstance.ClickYes();


            //Verify if the service has been deleted
            string expectedMsg = $"{title} has been deleted";
            string actualMsg = Driver.FindElement(By.XPath("/html/body/div/div[@class='ns-box-inner']")).Text;

            Console.WriteLine("actual msg is " + actualMsg);
            Console.WriteLine("expected msg is " + expectedMsg);

            Assert.That(actualMsg, Is.EqualTo(expectedMsg), "Serice has not been deleted");

        }
    }

}