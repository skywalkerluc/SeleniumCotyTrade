using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleneseOperation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleneseOperation.Operations
{
    public static class CreationOp
    {
        public static bool CreateUsers(IWebDriver _driver, List<Person> peopleImported)
        {
            try
            {
                List<Person> existingUsers = new List<Person>();
                foreach (var item in peopleImported)
                {
                    if (SearchOp.CheckIndividualExistance(_driver, item))
                        existingUsers.Add(item);
                    else if (SearchOp.CheckIndividualExistanceByCPF(_driver, item))
                        existingUsers.Add(item);
                    else
                        CreateIndividual(_driver, item);
                }
                if (existingUsers.Count > 0)
                {
                    foreach (var peop in existingUsers)
                    {
                        CompleteInfo(_driver, peop);
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        private static void CreateIndividual(IWebDriver _driver, Person item)
        {
            try
            {
                var windowInfo = _driver.CurrentWindowHandle;
                OpenCreateUserWindow(_driver, windowInfo);
                FillForm(_driver, item);
                windowInfo = _driver.CurrentWindowHandle;
                _driver.FindElements(By.TagName("input")).Last().Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                TabDealingOp.ChangeTab(windowInfo, _driver);

                //CompleteInfo(_driver, item);
            }
            catch (Exception)
            {
                return;
            }


        }

        /// <summary>
        /// TO DO
        /// </summary>
        /// <param name="_driver"></param>
        /// <param name="item"></param>
        public static void CompleteInfo(IWebDriver _driver, Person item)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //MainOperation.GetToUsersSignUp(_driver);
                bool exist = SearchOp.CheckIndividualExistance(_driver, item);
                Thread.Sleep(2000);
                if (exist)
                {
                    AccessUserInfo(_driver, item);
                    return;
                }
                else
                    return;
            }
            catch (Exception)
            {
                return;
            }


        }


        /// <summary>
        /// TO CHECK
        /// </summary>
        /// <param name="_driver"></param>
        /// <param name="item"></param>
        private static void AccessUserInfo(IWebDriver _driver, Person item)
        {
            try
            {
                Actions act = new Actions(_driver);
                
                var list = _driver.FindElement(By.ClassName("ui-jqgrid-bdiv"));
                var table = list.FindElement(By.TagName("table"));
                var rowsInTable = table.FindElements(By.TagName("tr"));
                var specificElement = rowsInTable.Last().FindElements(By.TagName("td"))[3];
                specificElement.Click();
                act.DoubleClick(specificElement).Perform();
                Thread.Sleep(TimeSpan.FromSeconds(3));


                SelectElement sel = new SelectElement(_driver.FindElements(By.TagName("select"))[3]);
                sel.SelectByValue(item.Role);

                sel = new SelectElement(_driver.FindElements(By.TagName("select"))[4]);
                sel.SelectByValue(item.Status);

                DealWithPosition(_driver, item);
            }
            catch (Exception)
            {
                return;
            }

        }

        /// <summary>
        /// TO-DO 
        /// </summary>
        /// <param name="_driver"></param>
        /// <param name="item"></param>
        private static void DealWithPosition(IWebDriver _driver, Person item)
        {
            _driver.FindElements(By.ClassName("ui-icon-extlink"))[1].Click();
            _driver.FindElements(By.ClassName("ui-pg-button"))[1].Click();
            _driver.FindElements(By.ClassName("ui-icon-extlink"))[0].Click();
            _driver.FindElements(By.ClassName("ui-pg-button"))[0].Click();
            _driver.FindElements(By.ClassName("DataTD"))[2].FindElements(By.TagName("input"))[0].SendKeys(item.Position);
            _driver.FindElements(By.ClassName("fm-button-icon-left"))[1].Click();
            Thread.Sleep(2000);

            Actions act = new Actions(_driver);
            var selectedItem = _driver.FindElements(By.ClassName("ui-jqgrid-bdiv"))[0].
                FindElements(By.TagName("div"))[0].FindElements(By.TagName("table"))[0].
                FindElements(By.TagName("tbody"))[0].FindElements(By.TagName("tr"))[1];
            selectedItem.Click();
            act.DoubleClick(selectedItem).DoubleClick(selectedItem).Build().Perform();

            Thread.Sleep(1000);
            _driver.FindElement(By.Id("sData")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("sData")).Click();
        }

        private static void OpenCreateUserWindow(IWebDriver _driver, string windowHandle)
        {
            _driver.FindElements(By.ClassName("appletButton"))[1].Click();
            TabDealingOp.ChangeTab(windowHandle, _driver);
            Thread.Sleep(2000);
        }

        public static bool CompleteInfoGroup(IWebDriver _driver, List<Person> peopleImported)
        {
            try
            {
                foreach (var item in peopleImported)
                {
                    CompleteInfo(_driver, item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        private static void FillForm(IWebDriver _driver, Person item)
        {
            _driver.FindElements(By.TagName("input"))[0].SendKeys(item.Name);
            _driver.FindElements(By.TagName("input"))[1].SendKeys(item.UserName);
            _driver.FindElements(By.TagName("input"))[2].SendKeys(item.Password);
        }

        private static void DoMultipleClicks(this IWebElement _element)
        {
            for (int i = 0; i < 8; i++)
            {
                _element.Click();
            }
        }

        private static string GetId(this IWebElement _element)
        {
            return _element.GetAttribute("id");
        }
    }
}
