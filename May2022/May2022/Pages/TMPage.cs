using May2022.Utilities;
using OpenQA.Selenium;
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
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_option_selected']"));
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
            Thread.Sleep(1500);

            // click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "May2022")
            {
                Console.WriteLine("New material record created successfully.");
            }
            else
            {
                Console.WriteLine("Material record hasn't been created.");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            // edit time and material
        }

        public void DeleteTM(IWebDriver driver)
        {
            // delete time and material
        }
    }
}
