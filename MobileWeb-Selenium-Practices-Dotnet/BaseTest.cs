using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumPractice
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class BaseTest
    {
        protected IWebDriver driver;


        [SetUp]
        public void OneTimeSetup()
        {
            driver = SeleniumHelper.InitDriver();
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();

        }

    }
}
