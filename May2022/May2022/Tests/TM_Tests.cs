using May2022.Pages;
using May2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace May2022
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void LoginActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }
        [Test]
        public void CreateTM()
        {
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);
        }
        [Test]
        public void EditTM()
        {
            // Edit TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver);
        }
        [Test]
        public void DeleteTM()
        {
            // Delete TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(driver);

        }
        [TearDown]
        public void CloseTestRun()
        {

        }
    }

}





