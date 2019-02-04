using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestCase
{
    class HomePageObject
    {
        IWebDriver driver;

        By ClickButton = By.ClassName("btnSignIn");
        
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public HomePageObject ClickLoginBtn()
        {
            driver.FindElement(ClickButton).Click();
            return new HomePageObject(driver);
        }

        public string HomePageControl()
        {
            return driver.Title;
        }

    }
}
