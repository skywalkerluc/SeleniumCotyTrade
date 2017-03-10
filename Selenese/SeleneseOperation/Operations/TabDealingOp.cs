using OpenQA.Selenium;

namespace SeleneseOperation.Operations
{
    public static class TabDealingOp
    {
        public static void ChangeTab(string winHandleBefore, IWebDriver driver)
        {
            foreach (string winHandle in driver.WindowHandles)
            {
                if (!winHandle.Equals(winHandleBefore))
                {
                    driver.SwitchTo().Window(winHandle);
                }
            }
        }

        public static void CloseTab(IWebDriver driver, string winHandleBefore)
        {
            driver.SwitchTo().Window(winHandleBefore);
            driver.Close();
        }
    }
}
