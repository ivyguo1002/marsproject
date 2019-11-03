using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAutomation.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MarsAutomation.Test
{
    [TestFixture]
    public class SearchSkillsTest : BaseTest
    {
        [Test]
        public void SearchbyCategory()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "SearchSkills");
            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(2, "SubCategory");

            //Search by category and subcategory
            var searchSkillsObj = new SearchSkills();
            searchSkillsObj.ClickSearch();
            Driver.Navigate().Refresh();
            searchSkillsObj.ClickCategory(category, subcategory);

            //Validate the result in ServiceDetails Page
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(category, serviceDetailsObj.Category.Text);
                    Assert.AreEqual(subcategory, serviceDetailsObj.SubCategory.Text);
                });
                Assert.AreEqual("Online", serviceDetailsObj.LocationType.Text);
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }
        }

        [Test]
        public void SearchbyFilters()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(ExcelPath, "SearchSkills");
            string searchSkill = ExcelLib.ReadData(3, "SearchSkills");

            //Search by skill first
            var searchSkillsObj = new SearchSkills();
            searchSkillsObj.ClickSearch();
            Driver.Navigate().Refresh();
            searchSkillsObj.InputSearchSkills(searchSkill);

            //Filter by Online
            searchSkillsObj.FilterbyOnline();
            //Validate the result in ServiceDetails Page
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);
                Assert.AreEqual("Online", serviceDetailsObj.LocationType.Text);
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }

            //Filter by Onsite
            searchSkillsObj.FilterbyOnsite();
            //Validate the result in ServiceDetails Pag
            for (int i = 0; i < searchSkillsObj.ServiceDetailsLinks.Count(); i++)
            {
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Shift).Click(searchSkillsObj.ServiceDetailsLinks[i]).KeyUp(Keys.Shift).Build().Perform();
                var serviceDetailsObj = new ServiceDetails();
                var windowList = Driver.WindowHandles;
                Driver.SwitchTo().Window(windowList[1]);
                Thread.Sleep(2000);
                Assert.AreEqual("On-Site", serviceDetailsObj.LocationType.Text,"Filter by Onsite failed");
                Driver.Close();
                Driver.SwitchTo().Window(windowList[0]);
            }

            //Filter by showall
            searchSkillsObj.FilterbyShowAll();
            Assert.IsTrue(searchSkillsObj.ValidateTitle(searchSkill));
        }
    }
}
