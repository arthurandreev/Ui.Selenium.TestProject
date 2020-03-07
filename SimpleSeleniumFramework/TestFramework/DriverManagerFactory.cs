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
                "--start-maximized"
               // "headless"
            );
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            Console.WriteLine("\nstarting chrome driver setup");
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory, options);   
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _objectContainer.RegisterInstanceAs(_driver);
            Console.WriteLine("chrome driver setup complete\n");
        }

        [AfterScenario]
        public void TearDown()
        {
            Console.WriteLine("\nkilling both webdriver and chrome driver");
            try
            {
                _driver.Quit();

                KillChromeDriver();
            }
            catch (Exception e)
            {
                Console.WriteLine($"TearDown method threw the following exception: {e} and stack trace {e.StackTrace}");
            }
            finally
            {
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
            Console.WriteLine("killed both webdriver and chrome driver\n");
        }

        public void KillChromeDriver()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine($"KillChromeDriver method threw the following exception: {e} and stack trace {e.StackTrace}");
            }

        }
    }
}
