using NUnit.Framework;
using OpenQA.Selenium;

namespace BattleShipTAF.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [OneTimeSetUp]
        public void Init()
        {
            Driver = WebDriverConcurrent.InitDriver(this.GetType());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            WebDriverConcurrent.KillDriver(this.GetType());
        }
    }
}
