using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleneseOperation.Domain;
using System;

namespace SeleneseOperation.Operations
{
    public class AcessPage
    {
        private const string loginPageLink = "https://cotytrade.cotyinc.com/cotytrade/index.php";
        public static void AccessCotyTrade(IWebDriver driver, UserLogin user, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            NavigateToLoginPage(driver);
            TryAuth(driver, user);
            var submit = wait.Until(f => { return driver.FindElement(By.Id("cmdOk")); });
            submit.Click();
        }

        private static void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Url = loginPageLink;
            driver.Navigate();
        }

        private static void TryAuth(IWebDriver driver, UserLogin user)
        {
            driver.FindElement(By.Name("username")).SendKeys(user.Login);
            driver.FindElement(By.Id("password")).SendKeys(user.Password);
        }
    }
}
