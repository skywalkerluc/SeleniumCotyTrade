using OpenQA.Selenium;
using SeleneseOperation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleneseOperation.Operations
{
    public static class SearchOp
    {
        private static TimeSpan fiveScds = TimeSpan.FromSeconds(5);
        private static void DiveIntoSearch(IWebDriver driver)
        {
            driver.FindElements(By.ClassName("ui-icon-search")).Last().Click();
        }

        public static List<Person> CheckExistance(IWebDriver driver, List<Person> peopleImported)
        {
            List<Person> returnedList = new List<Person>();
            foreach (var item in peopleImported)
            {
                Thread.Sleep(2000);
                if (CheckIndividualExistance(driver, item))
                    returnedList.Add(item);
                else if (CheckIndividualExistanceByCPF(driver, item))
                    returnedList.Add(item);
                        
            }

            return returnedList;
        }

        public static bool CheckIndividualExistance(IWebDriver driver, Person item)
        {
            DiveIntoSearch(driver);
            var input = driver.FindElements(By.TagName("input"))[1];
            input.SendKeys(item.Name);
            input.SendKeys(Keys.Enter);
            return CheckItensInList(driver);
        }

        private static bool CheckItensInList(IWebDriver driver)
        {
            Thread.Sleep(fiveScds);
            var list = driver.FindElement(By.ClassName("ui-jqgrid-bdiv"));
            var table = list.FindElement(By.TagName("table"));
            var rowsInTable = table.FindElements(By.TagName("tr")).Count;
            if (rowsInTable > 1)
                return true;
            return false;
        }

        public static bool CheckIndividualExistanceByCPF(IWebDriver driver, Person item)
        {
            DiveIntoSearch(driver);
            var input = driver.FindElement(By.Id("tr_5-0-6")).FindElement(By.TagName("input"));
            input.SendKeys(item.UserName);
            input.SendKeys(Keys.Enter);
            return CheckItensInList(driver);
        }
    }
}
