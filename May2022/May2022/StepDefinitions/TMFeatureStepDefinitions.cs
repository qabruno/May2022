using May2022.Pages;
using May2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace May2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a time and material record")]
        public void WhenICreateATimeAndMaterialRecord()
        {
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObj = new TMPage();

            string newCode = tmPageObj.GetNewCode(driver);
            string newTypeCode = tmPageObj.GetNewTypeCode(driver);
            string newDescription = tmPageObj.GetNewDescription(driver);
            string newPrice = tmPageObj.GetNewPrice(driver);


            Assert.That(newCode == "May2022", "Actual code and expected code do not match.");
            Assert.That(newTypeCode == "M", "Actual type code and expected type code do not match.");
            Assert.That(newDescription == "May2022", "Actual description and expected description do not match.");
            Assert.That(newPrice == "$12.00", "Actual price and expected price do not match.");
        }

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver, p0, p1, p2);
        }

        [Then(@"the record should have the updated '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p0, string p1, string p2)
        {
            TMPage tmPageObj = new TMPage();

            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.That(editedDescription == p0, "Actual description and expected description do not match.");
            Assert.That(editedCode == p1, "Actual code and expected code do not match.");
            Assert.That(editedPrice == p2, "Actual price and expected price do not match.");
        }


    }
}
