using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestCase
{
    class SearchResultsSecondPageObject
    {
        IWebDriver driver;

        By AddFavoriteButton = By.XPath("//li[3]/div/div[2]/span[2]");
        By BasketButton = By.XPath("//*[@id='header']/div/div/div[2]/div[2]/div[4]/a");
        By FavoritesButton = By.XPath("//*[@id='wrapper']/div[2]/div/div[1]/div[2]/h2/a");
     
        public SearchResultsSecondPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchResultsSecondPageObject AddFavoriteThirdProduct()
        {
            driver.FindElement(AddFavoriteButton).Click();
            return new SearchResultsSecondPageObject(driver);
        }
        public SearchResultsSecondPageObject NavigateToBasket()
        {
            driver.FindElement(BasketButton).Click();
            return new SearchResultsSecondPageObject(driver);
        }

        public SearchResultsSecondPageObject NavigateToFavorites()
        {
            driver.FindElement(FavoritesButton).Click();
            return new SearchResultsSecondPageObject(driver);
        }

    }
}
