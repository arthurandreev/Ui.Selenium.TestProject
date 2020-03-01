using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework
{
    [Binding]
    public class DriverManagerFactory
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        public DriverManagerFactory(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [BeforeScenario]
        public void SetupChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(
                "incognito",
               // "headless",
                "--start-maximized"
            );
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            Console.WriteLine("\nsetting up chrome driver");
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory, options);   
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _objectContainer.RegisterInstanceAs(_driver);
            Console.WriteLine("chrome driver setup complete\n");
        }

        public void KillChromeDriver()
        {
            foreach (var p in Process.GetProcesses())
            {
                var name = p.ProcessName.ToLower();
                if (name == "chromedriver.exe")
                {
                    Console.WriteLine("killing chromedriver process");
                    p.Kill();
                }
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            Console.WriteLine("\nquitting webdriver and killing chrome driver");
            try
            {
                _driver.Quit();

                KillChromeDriver();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
            Console.WriteLine("successfully quit webdriver and killed chrome driver\n");
        }
    }
}
