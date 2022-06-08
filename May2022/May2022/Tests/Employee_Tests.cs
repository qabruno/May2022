using May2022.Pages;
using May2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests : CommonDriver
    {
        // page objects initialization
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();


        [Test]
        public void CreateEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEMployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.DeleteEmployee(driver);
        }
    }
}
