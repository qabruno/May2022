using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2022.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            // click on Administration tab
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            // select Time & Materials from dropdown list
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
        }
    }
}
