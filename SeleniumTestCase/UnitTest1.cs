using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestCase
{
    [TestFixture]
    public class SeleniumTest
    {
        [SetUp]
        public void Init()
        {
            TestProperties.driver = new ChromeDriver();
            TestProperties.driver.Navigate().GoToUrl("https://www.n11.com/");

        }

        [Test]
        public void NavigateToLogin()
        {
            HomePageObject page = new HomePageObject(TestProperties.driver);
            Assert.AreEqual(page.HomePageControl(), "n11.com - Alışverişin Uğurlu Adresi");
            Console.WriteLine("HomePage Navigated");

            page.ClickLoginBtn();

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        [Test]
        public void Login()
        {
            NavigateToLogin();
            LoginPageObject page = new LoginPageObject(TestProperties.driver);
            page.Login("seleniumtest111@gmail.com", "qwerty1234");

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);

        }

        [Test]
        public void Search()
        {
            Login();

            SearchPageObject page = new SearchPageObject(TestProperties.driver);
            page.Search("samsung");

            Assert.IsTrue(page.SearchControl().Text.Contains("Samsung"));
            Console.WriteLine("Products found for Samsung");

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);

        }

        [Test]
        public void SearchResults()
        {
            Search();

            SearchResultsPageObject page = new SearchResultsPageObject(TestProperties.driver);
            page.ClickSecondPagination();

            Assert.IsTrue(page.PageControl().Contains("Samsung - n11.com - 2/"));
            Console.WriteLine("Second page of results displaying.");

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        [Test]
        public void AddFavoriteItem()
        {
            SearchResults();

            SearchResultsSecondPageObject page = new SearchResultsSecondPageObject(TestProperties.driver);

            page.AddFavoriteThirdProduct();

            IWebElement favoriteItem = TestProperties.driver.FindElement(By.XPath("//li[3]/div/div/a/h3"));
            var favoritedproduct = favoriteItem.Text.ToString();
            FavoriteHelper.FavoritedProduct = favoritedproduct;

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        public void NavigateToFavorited()
        {
            AddFavoriteItem();

            SearchResultsSecondPageObject page = new SearchResultsSecondPageObject(TestProperties.driver);
            page.NavigateToBasket();
            page.NavigateToFavorites();

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        [Test]
        public void CheckFavoritedItem()
        {
            NavigateToFavorited();

            FavoritesPageObject page = new FavoritesPageObject(TestProperties.driver);

            foreach (var product in page.GetFavoritedList())
            {
                if (product.Text.ToString() == FavoriteHelper.FavoritedProduct)
                {
                    Assert.That(product.Text.ToString, Is.EqualTo(FavoriteHelper.FavoritedProduct));
                    Console.WriteLine("The product you have added is in your favorite list");
                }
            }

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        [Test]
        public void DeleteFavoriteItem()
        {
            CheckFavoritedItem();

            FavoritesPageObject page = new FavoritesPageObject(TestProperties.driver);
            page.DeleteProduct();

            System.Threading.Thread.Sleep(1000);

            page.DeleteConfirm();

            bool productInList = false;

            System.Threading.Thread.Sleep(1000);

            foreach (var product in page.GetFavoritedList())
            {
                if (product.Text.ToString() == FavoriteHelper.FavoritedProduct)
                {
                    productInList = true;
                    Console.WriteLine("The product is still on your list");
                }
            }

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);

            Assert.IsFalse(productInList);
            Console.WriteLine("Removed Product not in your favorite list");

            TestProperties.driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(300);
        }

        [TearDown]
        public void TearDown()
        {
            TestProperties.driver.Quit();
        }
    }
}

