using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace XUnitTestA8
{
    public class SeleniumTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [Fact]
        public void EnterOrder()
        {
            string url = "https://localhost:44390/Pizza/EnterOrder";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("lang=en-GB");
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(_driver, new TimeSpan(0, 5, 5));

            var element = _wait.Until(wt => wt.FindElement(By.Id("Pizza")));
            var selectElement = new SelectElement(element);
            selectElement.SelectByText("Pizza50");

            _driver.FindElement(By.Id("PickupTime")).SendKeys("2024");

            _driver.FindElement(By.ClassName("btn")).Click();

            
            _wait.Until(wt => wt.FindElement(By.Id("Success")).Text == "True");

            _driver.Close();
            _driver.Dispose();
        }

        [Fact]
        public void GetAllOrders()
        {
            string url = "https://localhost:44390/Pizza/GetAllOrders";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("lang=en-GB");
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(_driver, new TimeSpan(0, 5, 5));
            _wait.Until(wt => wt.FindElement(By.TagName("h2")).Text == "All orders");
            _driver.Close();
            _driver.Dispose();
        }

        [Fact]
        public void RemoveOrder()
        {
            #region EnterOrder

            string url = "https://localhost:44390/Pizza/EnterOrder";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("lang=en-GB");
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(_driver, new TimeSpan(0, 5, 5));

            var element = _wait.Until(wt => wt.FindElement(By.Id("Pizza")));
            var selectElement = new SelectElement(element);
            selectElement.SelectByText("Pizza50");

            _driver.FindElement(By.Id("PickupTime")).SendKeys("2024");

            _driver.FindElement(By.ClassName("btn")).Click();

            #endregion

            url = "https://localhost:44390/Pizza/GetAllOrders";
            _driver.Navigate().GoToUrl(url);

            _wait = new WebDriverWait(_driver, new TimeSpan(0, 5, 5));

            var element2 = _wait.Until(wt => wt.FindElement(By.XPath("/html/body/div/table/tbody/tr[1]/td[6]/a")));// delete the first order.
            element2.Click();

            _wait.Until(wt => wt.FindElement(By.TagName("h2")).Text == "All orders");

            _driver.Close();
            _driver.Dispose();
        }
    }
}
