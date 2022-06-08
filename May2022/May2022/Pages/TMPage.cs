using May2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace May2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // click on create new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span", 5);

            // select material from typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            // identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("May2022");

            // identify the description textbox and input a code
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("May2022");

            // identify the price per unit textbox and input a code
            IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            // click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

        }

        public string GetNewCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetNewTypeCode(IWebDriver driver)
        {
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTypeCode.Text;
        }

        public string GetNewDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetNewPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(1000);
            IWebElement goToLastPageBtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn.Click();
            Thread.Sleep(2000);

            IWebElement findNewRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (findNewRecord.Text == "May2022")
            {
                // Click on the Edit Button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(1000);
            }
            else
            {
                Assert.Fail("Record to be edited not found.");
            }

            // Click on "TypeCode" from dropdown list and set the Type Code
            IWebElement typeCodeDropdown1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown1.Click();
            Thread.Sleep(1000);

            IWebElement selectMaterial = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            selectMaterial.Click();
            Thread.Sleep(1000);

            // Click on "Code" from Textbox and set the code
            IWebElement codeTextBox1 = driver.FindElement(By.Id("Code"));
            codeTextBox1.Clear();
            codeTextBox1.SendKeys("Automated Script1");
            Thread.Sleep(1000);

            // Click on "Description" from Textbox and set the description
            IWebElement descriptionTextBox1 = driver.FindElement(By.Id("Description"));
            descriptionTextBox1.Clear();
            descriptionTextBox1.SendKeys("Automated Script1 is changed");
            Thread.Sleep(1000);

            // Click on "Price per unit" textbox and clear the price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            priceTag.Click();
            Thread.Sleep(1000);

            IWebElement pricePerUnit1 = driver.FindElement(By.Id("Price"));
            pricePerUnit1.Clear();
            Thread.Sleep(1000);

            priceTag.Click();
            Thread.Sleep(1000);

            // IWebElement pricePerUnit2 = testDriver.FindElement(By.Id("Price"));
            pricePerUnit1.SendKeys("170.00");
            Thread.Sleep(500);

            // Click on "Save" button
            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();
            Thread.Sleep(2000);

            // Assert that Time record has been edited.
            IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn1.Click();
            Thread.Sleep(2000);

            IWebElement newCodeCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            // Assertion
            Assert.That(newCodeCreated.Text == "Automated Script1", "Actual code and expected code do not match.");
        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(1500);
            IWebElement goToLastPageBtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn.Click();
            Thread.Sleep(2000);

            // Click on the Delete Button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept();

            // Assert that Time record has been deleted.
            IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn1.Click();
            Thread.Sleep(2000);

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            // Assertion
            Assert.That(editedCode.Text != "Automated Script1", "Time and material record hasn't been deleted succesfully.");

        }
    }
}
