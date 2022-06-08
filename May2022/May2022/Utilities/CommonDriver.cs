using May2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2022.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        LoginPage loginPageObj = new LoginPage();
        

        [OneTimeSetUp]
        public void LoginActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition

            loginPageObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
