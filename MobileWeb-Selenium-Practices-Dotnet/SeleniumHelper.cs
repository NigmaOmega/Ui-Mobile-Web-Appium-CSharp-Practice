using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Policy;

namespace SeleniumPractice
{
    public static class SeleniumHelper
    {
        private static readonly ConfigurationHelper config = ConfigurationHelper.Instance;


        public static IWebDriver InitDriver()
        {
            var isGrid = config.IsSeleniumGrid;
            IWebDriver driver;
            if (isGrid)
            {
                driver = InitGridDriver();
            }
            else
            {
                driver = InitNormalDriver();
            }
          //  driver.Manage().Window.Maximize();

            return driver;
        }

        private static IWebDriver InitNormalDriver()
        {
            switch (config.Browser)
            {
                case "Chrome":
                    return InitNormalChromeDriver();
                default:
                    return InitNormalChromeDriver();
            }
        }

        [Obsolete]
        private static IWebDriver InitNormalChromeDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "11.0");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "ixel 3a XL API 30");
            capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.SetCapability(MobileCapabilityType.BrowserName, "Chrome");
            capabilities.SetCapability("unicodeKeyboard", true);
            capabilities.SetCapability("resetKeyboard", true);
            return new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
        }

        private static IWebDriver InitGridDriver()
        {
            switch (config.Browser)
            {
                case "Chrome":
                    return InitChromeGridDriver();
                default:
                    return InitChromeGridDriver();
            }
        }

        private static IWebDriver InitChromeGridDriver()
        {
            ChromeOptions options = new ChromeOptions();
            if (config.IsHeadless)
            {
                options.AddArgument("--headless");
            }

            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub/"), options);


            return driver;
        }
    }
}