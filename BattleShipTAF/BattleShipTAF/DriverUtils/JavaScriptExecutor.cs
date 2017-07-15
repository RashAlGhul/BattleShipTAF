using System.Collections.Generic;
using OpenQA.Selenium;

namespace BattleShipTAF.DriverUtils
{
    internal static class JavaScriptExecutor
    {
        internal static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            Execute(driver, "arguments[0].scrollIntoView(true);", element);
        }

        internal static void ScrollIntoView(IWebDriver driver, IList<IWebElement> elements)
        {
            Execute(driver, "arguments[0].scrollIntoView(true);", elements);
        }

        internal static void Click(IWebDriver driver, IWebElement element)
        {
            Execute(driver, "arguments[0].click();", element);
        }


        private static void Execute(IWebDriver driver, string js, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(js, element);
        }

        private static void Execute(IWebDriver driver, string js, IList<IWebElement> elements)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(js, elements);
        }
    }
}
