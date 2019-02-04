using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestCase
{
    class SearchResultsPageObject
    {
        IWebDriver driver;

        By SecondPaginationButton = By.XPath("//*[@id='contentListing']/div/div/div[2]/div[3]/a[2]");
        

        public SearchResultsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchResultsPageObject ClickSecondPagination()
        {
            driver.FindElement(SecondPaginationButton).Click();

            return new SearchResultsPageObject(driver);
        }

        public string PageControl()
        {
            return driver.Title;
        }

    }
}
