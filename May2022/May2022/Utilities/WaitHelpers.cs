using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2022.Utilities
{
    public class WaitHelpers
    {
        // Generic function to wait for element to be clickable
        public static void WaitToBeClickable(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            
            if (locator == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            if(locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }

        }

        public static void WaitToBeVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locator == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            if (locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            }

        }
    }
}
