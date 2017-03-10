using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleneseOperation.Domain;
using System;
using System.Linq;
using System.Threading;

namespace SeleneseOperation.Operations
{
    public static class MainOperation
    {
        private static TimeSpan time = TimeSpan.FromSeconds(20);
        private static TimeSpan fiveScds = TimeSpan.FromSeconds(5);
        private static TimeSpan twoScds = TimeSpan.FromSeconds(2);
        private const string variablePath = "C:\\Users\\Skywalker\\Desktop\\geckodriver";
        private const string secVariablePath = "C:\\Users\\l.bezerra.ferreira\\Desktop\\WorkspaceSelenium\\";
        private const string profilePath = "C:\\Users\\Skywalker\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\6u2ha89v.Selenium";
        private const string secProfilePath = "C:\\Users\\l.bezerra.ferreira\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\6owa6dsx.Selenium";

        public static IWebDriver Initialize()
        {
            IWebDriver driver = Configure();

            string winHandleBefore = driver.CurrentWindowHandle;
            string firstTab = driver.CurrentWindowHandle;
            UserLogin user = new UserLogin();
            AcessPage.AccessCotyTrade(driver, user, time);
            Thread.Sleep(twoScds);
            TabDealingOp.ChangeTab(winHandleBefore, driver);
            winHandleBefore = driver.CurrentWindowHandle;
            Thread.Sleep(twoScds);
            ManageSession(driver);
            Thread.Sleep(5000);
            TabDealingOp.CloseTab(driver, firstTab);
            TabDealingOp.ChangeTab(winHandleBefore, driver);
            driver.Manage().Window.Maximize();
            GetToUsersSignUp(driver);
            return driver;
        }

        public static void GetToUsersSignUp(IWebDriver driver)
        {
            var adminButton = driver.FindElements(By.Id("sp_5-0-e")).Last();
            Actions action = new Actions(driver);
            action.MoveToElement(adminButton).Click();
            WebDriverWait wait = new WebDriverWait(driver, fiveScds);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("d-0-2207")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('5-0-e').click()");
            js.ExecuteScript("document.getElementById('d-0-2207').click()");
        }

        private static void ManageSession(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            var input = wait.Until(func =>
            {
                return driver.FindElements(By.TagName("input"))[1];
            });
            input.Click();
        }

        private static IWebDriver Configure()
        {
            FirefoxProfile firefoxProfile = GetFirefoxSeleniumProfile();
            FirefoxOptions opt = new FirefoxOptions()
            {
                Profile = firefoxProfile
            };

            var driver = new FirefoxDriver(ConfigService(), opt, TimeSpan.FromSeconds(60));
            driver.Manage().Timeouts().ImplicitlyWait(time).SetPageLoadTimeout(time);
            return driver;
        }

        private static FirefoxProfile GetFirefoxSeleniumProfile()
        {
            try
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile(secProfilePath);
                return firefoxProfile;
            }
            catch (Exception)
            {
                return new FirefoxProfile();
            }
        }

        private static FirefoxDriverService ConfigService()
        {
            var service = FirefoxDriverService.CreateDefaultService(secVariablePath);
            service.HideCommandPromptWindow = true;
            return service;
        }

    }
}
