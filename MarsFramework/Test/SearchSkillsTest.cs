using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;

namespace MarsFramework.Test
{
    [TestFixture]
    public class SearchSkillsTest:Global.Base
    {
        [Test]
        public void SearchbyCategory()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
            string searchSkill = ExcelLib.ReadData(2, "SearchSkills");
            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(2, "SubCategory");
            string username = ExcelLib.ReadData(2,"User");
            string title = ExcelLib.ReadData(2, "Title");

            //Search by category and skillname
            var searchSkillsObj = new SearchSkills();
            searchSkillsObj.ClickSearch();
            searchSkillsObj.ClickCategory(category, subcategory);
            searchSkillsObj.InputSearchSkills(searchSkill);

            //Validate the result
            //The expected result should have title and username as expected
            Assert.IsTrue(searchSkillsObj.ValidateResults(username,title),"search skills by category failed");
        }

        [Test]
        public void SearchbyFilters()
        {
            //Read data from Excel file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
            string searchSkill = ExcelLib.ReadData(3, "SearchSkills");
            string username_Onsite = ExcelLib.ReadData(3, "User");
            string title_Onsite = ExcelLib.ReadData(3, "Title");
            string username_Online = ExcelLib.ReadData(4,"User");
            string title_Online = ExcelLib.ReadData(4,"Title");
 

            //Search by skillname
            var searchSkillsObj = new SearchSkills();
            searchSkillsObj.ClickSearch();
            searchSkillsObj.InputSearchSkills(searchSkill);

            //filter by Online
            searchSkillsObj.FilterbyOnline();
            Assert.IsTrue(searchSkillsObj.ValidateResults(username_Online,title_Online), "Filtered by Online failed");

            //filter by Onsite
            searchSkillsObj.FilterbyOnsite();
            Assert.IsTrue(searchSkillsObj.ValidateResults(username_Onsite,title_Onsite),"Filtered by Onsite failed");

            //filter by showall
            searchSkillsObj.FilterbyShowAll();
            Assert.IsTrue(searchSkillsObj.ValidateTitle(searchSkill), "Filtered by ShowAll failed");
        }
    }
}
