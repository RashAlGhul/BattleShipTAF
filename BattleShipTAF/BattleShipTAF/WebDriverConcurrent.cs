using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipTAF.DriverUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BattleShipTAF
{
    class WebDriverConcurrent
    {
        private static readonly ConcurrentDictionary<Type, IWebDriver> DriverPool = new ConcurrentDictionary<Type, IWebDriver>();
        private static readonly string CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        public static IWebDriver InitDriver(Type type)
        {
            IWebDriver driver;
            if (!DriverPool.TryGetValue(type, out driver))
            {
                switch (Config.Driver.ToUpper())
                {
                    case "CHROME":
                        driver = InitChromeDriver();
                        break;
                    case "FIREFOX":
                        driver = InitFirefoxDriver();
                        break;
                    default:
                        driver = InitChromeDriver();
                        break;
                }
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(90));
                bool succesfullAdding = false;
                while (!succesfullAdding)
                {
                    succesfullAdding = DriverPool.TryAdd(type, driver);
                }
            }

            return driver;
        }

        private static IWebDriver InitChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("no-sandbox");
            IWebDriver driver = new ChromeDriver(CurrentDirectory, options, TimeSpan.FromMinutes(3));

            return driver;
        }

        private static IWebDriver InitFirefoxDriver()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            FirefoxOptions options = new FirefoxOptions();
            IWebDriver driver = new FirefoxDriver(service, options, TimeSpan.FromMinutes(3));
            driver.Manage().Window.Maximize();

            return driver;
        }

        public static void KillDriver(Type type)
        {
            DriverPool[type].Quit();
            IWebDriver driver;

            bool isDriverRemoved = false;
            while (!isDriverRemoved)
            {
                isDriverRemoved = DriverPool.TryRemove(type, out driver);
            }
            driver = null;
        }
    }
}
