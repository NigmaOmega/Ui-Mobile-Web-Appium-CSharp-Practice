using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileWeb_Selenium_Practices_Dotnet.Commons.Selenium
{
    public class Javascripts
    {
        IWebDriver driver;
        public Javascripts(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Click(By by)
        {
            var element = driver.WaitUtil(by, WaitType.WaitUtilExist);
            driver.JsExecute("arguments[0].click();", element);
        }
    }
}
