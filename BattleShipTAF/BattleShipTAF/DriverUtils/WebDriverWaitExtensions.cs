using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BattleShipTAF.DriverUtils
{
    public static class WebDriverWaitExtensions
    {
        public static IWebElement Wait(this IWebDriver driver, Func<IWebDriver, IWebElement> condition, int timeout = 180)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(condition);
        }

        public static IList<IWebElement> Wait(this IWebDriver driver, Func<IWebDriver, IList<IWebElement>> condition, int timeout = 180)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(condition);
        }

        public static bool Wait(this IWebDriver driver, Func<IWebDriver, bool> condition, int timeout = 180)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(condition);
        }
    }
}
