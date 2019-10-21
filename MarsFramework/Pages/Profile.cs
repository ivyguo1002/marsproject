using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    internal class Profile
    {
        #region  Initialize Web Elements 
        //Click on Edit button
        IWebElement AvailabilityTimeEdit => Driver.FindElement(By.XPath("//span[contains(text(),'Part Time')]//i[@class='right floated outline small write icon']"));

        //Click on Availability Time dropdown
        IWebElement AvailabilityTime => Driver.FindElement(By.Name("availabiltyType"));

        //Click on Availability Time option}
        IWebElement AvailabilityTimeOpt => Driver.FindElement(By.XPath("//option[@value='0']"));

        //Click on Availability Hour dropdown
        IWebElement AvailabilityHours => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[3]/div"));

        //Click on salary
        IWebElement Salary => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[4]/div"));

        //Click on Location
        IWebElement Location => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div"));

        //Choose Location
        IWebElement LocationOp => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div/div[2]"));

        //Click on City
        IWebElement City => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div"));

        //Choose City
        IWebElement CityOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div/div[2]"));

        //Click on Add new to add new Language
        IWebElement AddNewLangBtn => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddLangText { get; set; }

        //Enter the Language on text box
        IWebElement ChooseLang => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select"));

        //Enter the Language on text box
        IWebElement ChooseLangOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));

        //Add Language
        IWebElement AddLang => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[3]/input[1]"));

        //Click on Add new to add new skill
        IWebElement AddNewSkillBtn => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/table/thead/tr/th[3]/div"));

        //Enter the Skill on text box
        IWebElement AddSkillText => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[1]/input"));

        //Click on skill level dropdown
        IWebElement ChooseSkill => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select"));

       //Choose the skill level option
        IWebElement ChooseSkilllevel => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select/option[3]"));

        //Add Skill
        IWebElement AddSkill => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/span/input[1]"));

        //Click on Add new to Educaiton
        IWebElement AddNewEducation => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/table/thead/tr/th[6]/div"));

        //Enter university in the text box
        IWebElement EnterUniversity => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[1]/input"));

        //Choose the country
        IWebElement ChooseCountry => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select"));

        //Choose the country option
        IWebElement ChooseCountryOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]"));

        //Click on Title dropdown
        IWebElement ChooseTitle => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select"));

        //Choose title
        IWebElement ChooseTitleOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]"));

        //Degree
        IWebElement Degree => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[2]/input"));

        //Year of graduation
        IWebElement DegreeYear => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select"));

        //Choose Year
        IWebElement DegreeYearOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]"));

        //Click on Add
        IWebElement AddEdu => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[3]/div/input[1]"));

        //Add new Certificate
        IWebElement AddNewCerti => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/table/thead/tr/th[4]/div"));

        //Enter Certification Name
        IWebElement EnterCerti => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[1]/div/input"));

        //Certified from
        IWebElement CertiFrom => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[1]/input"));

        //Year
        IWebElement CertiYear => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select"));

        //Choose Opt from Year
        IWebElement CertiYearOpt => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select/option[5]"));

        //Add Ceritification
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddCerti { get; set; }

        //Add Desctiption
        IWebElement Description => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[8]/div/div[2]/div[1]/textarea"));

        //Click on Save Button
        IWebElement Save => Driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[8]/div/div[4]/span/button[1]"));

        #endregion

        internal void EditProfile()
        {

        }
    }
}