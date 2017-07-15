using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BattleShipTAF.DriverUtils;

namespace BattleShipTAF.PageObjects
{
    class BasePage
    {
        protected IWebDriver Driver;
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void NavigateHere()
        {
            Driver.Navigate().GoToUrl(Config.BaseURL);
        }
    }
}
