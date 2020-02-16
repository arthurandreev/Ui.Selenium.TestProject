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

        protected void MoveToElement(IWebElement element, string elementText = "<no element text supplied>")
        {
            try
            {
                Actions action = new Actions(Driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Cannot move to the following element: {elementText}");
                Console.WriteLine(e);
            }
        }
        protected void ClickElement(IWebElement element, string elementText = "<no element text supplied>")
        {
            Console.WriteLine($"Clicking {elementText} at location {element.Location}");
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(condition => element != null && element.Enabled);
                MoveToElement(element, elementText);
                element.Click();
            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine(e);
                element.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cannot click the following element: {elementText}");
                Console.WriteLine(e);
            }
        }
        protected void WaitforElementToBeVisible(By by, int timeoutInSeconds)
        {
            var element = Driver.FindElement(by);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(condition => element.Displayed);
        }

        protected void WaitforElementToBeClickable(IWebElement element, int timeoutInSeconds)
        {
            
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(condition => element.Enabled);
        }

        protected void WaitforElementToBeVisible(IWebElement element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(condition => element.Displayed);
        }

        protected bool WaitForElementToBeInvisible(By by, int timeoutInSeconds)
        {
            try
            {
                var element = Driver.FindElement(by);
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(condition => !element.Displayed);
                return !element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }

        protected bool WaitForElementToBeInvisible(IWebElement element, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(condition => !element.Displayed);
                return !element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }
    }
}
