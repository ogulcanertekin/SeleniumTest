using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestCase
{
    class LoginPageObject
    {
        IWebDriver driver;

        By Email = By.Id("email");
        By Password = By.Id("password");
        By LoginButton = By.Id("loginButton");

        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPageObject Login(string email,string password)
        {
            driver.FindElement(Email).SendKeys(email);
            driver.FindElement(Password).SendKeys(password);
            driver.FindElement(LoginButton).Click();

            return new LoginPageObject(driver);
        }
        
    }
}
