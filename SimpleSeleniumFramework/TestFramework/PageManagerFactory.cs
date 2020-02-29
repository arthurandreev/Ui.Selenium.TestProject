using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SimpleSeleniumFramework.TestFramework
{
    public abstract class PageManagerFactory
    {
        protected IWebDriver Driver;
        protected PageManagerFactory(IWebDriver driver)
        {
            Driver = driver;
        }

        protected string GetUrl() => Driver.Url;
        protected void GoToUrl(string url) => Driver.Navigate().GoToUrl(url);
        protected IWebElement GetElement(By by)
        {
            return Driver.FindElement(by);
        }

        protected IList<IWebElement> GetElements(By by)
        {
            return Driver.FindElements(by);
        }

        protected void MoveToElement(IWebElement element)
        {
            try
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Cannot move to the following element: {element.Text}");
                Console.WriteLine(e);
            }
        }

        protected void ClickElement(IWebElement element)
        {
            Console.WriteLine($"Clicking {element.Text} at location {element.Location}");
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(condition => element != null && element.Enabled);
                MoveToElement(element);
                element.Click();
            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cannot click the following element: {element.Text}");
                Console.WriteLine(e);
            }
        }

        protected void FluentWaitForElementToAppear(By by, int timeout, int pollInterval)
        {
            var fluentWait = new DefaultWait<IWebDriver>(Driver)
            {
                Timeout = TimeSpan.FromSeconds(timeout),
                PollingInterval = TimeSpan.FromMilliseconds(pollInterval)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => x.FindElement(by));
        }

        protected void FluentWaitForElementToDisappear(By by, int timeout, int pollInterval)
        {
            var fluentWait = new DefaultWait<IWebDriver>(Driver)
            {
                Timeout = TimeSpan.FromSeconds(timeout),
                PollingInterval = TimeSpan.FromMilliseconds(pollInterval)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => (x.FindElements(by).Count == 0));
        }

        protected void DismissAlert()
        {
            try
            {
                Driver.SwitchTo().Alert().Dismiss();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("Alert not present");
            }
        }
    }
}
