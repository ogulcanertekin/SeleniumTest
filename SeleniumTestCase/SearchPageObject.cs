using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestCase
{
    class SearchPageObject
    {
        IWebDriver driver;

        By SearchInput= By.Id("searchData");
        By SearchButton = By.ClassName("searchBtn");
        By ResultText = By.ClassName("resultText");

        public SearchPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchPageObject Search(string input)
        {
            driver.FindElement(SearchInput).SendKeys(input);
            driver.FindElement(SearchButton).Click();
            return new SearchPageObject(driver);
        }

        public IWebElement SearchControl()
        {
           return driver.FindElement(ResultText);
        }

    }
}
