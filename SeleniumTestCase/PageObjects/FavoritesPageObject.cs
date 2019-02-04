using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestCase
{
    class FavoritesPageObject
    {
        By DeleteButton = By.XPath("//*[@id='view']/ul/li[1]/div/div[3]/span");
        By DeleteConfirmButton = By.XPath("/html/body/div[5]/div/div/span");

        IWebDriver driver;
        
        public FavoritesPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> GetFavoritedList()
        {
            return driver.FindElements(By.XPath("//*/div/a/h3")).ToList();
        }

        public FavoritesPageObject DeleteProduct()
        {
            driver.FindElement(DeleteButton).Click();
            return new FavoritesPageObject(driver);
        }
        public FavoritesPageObject DeleteConfirm()
        {
            driver.FindElement(DeleteConfirmButton).Click();
            return new FavoritesPageObject(driver);
        }

    }
}
