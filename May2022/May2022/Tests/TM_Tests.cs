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
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        // page object initialization

        TMPage tmPageObj = new TMPage();
        HomePage homePageObj = new HomePage();

        [Test, Order(1), Description("Create time and material record with valid data")]
        public void CreateTM()
        {
            
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            tmPageObj.CreateTM(driver);
        }
        [Test, Order(2), Description("Edit time and material record created in test number 1")]
        public void EditTM()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // Edit TM
            tmPageObj.EditTM(driver);
        }
        [Test, Order(3), Description("Delete time and material record edited in test number 2")]
        public void DeleteTM()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // Delete TM
            tmPageObj.DeleteTM(driver);

        }

    }

}





