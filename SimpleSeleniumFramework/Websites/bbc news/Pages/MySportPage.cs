﻿using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;
using System;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
   public class MySportPage : PageManagerFactory
    {
        private readonly string Url = "https://www.bbc.co.uk/sport/my-sport";
        private readonly string Username = "testautomation1011@gmail.com";
        private readonly string Password = "ghBabcdFaq$456$";

        private IWebElement NeedHelpSigningInLink => GetElement(By.XPath("//span[text() = 'Need help signing in?']"));
        private IWebElement TakeASurveyButton => GetElement(By.XPath("//*[@id='id_1583534363389_0'][(text() = 'Take survey(opens in a new window)')]"));
        private IWebElement OkCookiesButton => GetElement(By.Id("bbcprivacy-continue-button"));
        private IWebElement AcceptCookiesButton => GetElement(By.Id("bbccookies-continue-button"));
        private IWebElement SignInOnLandingPage => GetElement(By.XPath("//*[@id='idcta-link']//span[contains(text(), 'Sign in')]"));
        private IWebElement SignInButtonOnSigninPage => GetElement(By.Id("submit-button"));
        private IWebElement EmailTextBox => GetElement(By.Id("user-identifier-input"));
        private IWebElement PasswordTextBox => GetElement(By.Id("password-input"));
        private IWebElement NoThanksButton => GetElement(By.XPath("//*[@id='no']//span[(text() = 'No thanks')]"));
        private IWebElement EditMySport => GetElement(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"));
        
        public MySportPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) {}
        public void AcceptCookies()
        {
            FluentWaitForElementToAppear(By.Id("bbcprivacy-continue-button"), 10, 500);
            ClickElement(OkCookiesButton);
            FluentWaitForElementToAppear(By.Id("bbccookies-continue-button"), 10, 500);
            ClickElement(AcceptCookiesButton);
        }

        public void NavigateToMySportPage()
        {
            GoToUrl(Url);
            DismissAlertIfPresent();
            AcceptCookies();
            Assert.AreEqual(GetUrl(), Url);
        }

        public void NavigateToSigninPage()
        {
            FluentWaitForElementToAppear(By.XPath("//*[contains(text(), 'Sign in')]"), 10, 500);
            ClickElement(SignInOnLandingPage);          
        }

        public void EnterUsernameAndPassword()
        {
           DismissAlertIfPresent();
           FluentWaitForElementToAppear(By.Id("submit-button"), 10, 500);
           EmailTextBox.SendKeys(Username);
           PasswordTextBox.SendKeys(Password);
           Assert.IsTrue(NeedHelpSigningInLink.Displayed); 
        }

        public void ClickToSignin()
        {
            ClickElement(SignInButtonOnSigninPage);
        }

        public void ValidateMyBbcSportsNewsPage()
        {
            DismissAlertIfPresent();
            FluentWaitForElementToAppear(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"), 20, 500);
            TakeScreenshot();
            Assert.IsTrue(EditMySport.Enabled);
        }

        public void DismissAlertIfPresent()
        {
                try
                {
                    Driver.SwitchTo().Frame("edr_l_first");
                    FluentWaitForElementToAppear(By.XPath("//*[@id='no']//span[(text() = 'No thanks')]"), 10, 500);
                    ClickElement(NoThanksButton);
                    Driver.SwitchTo().DefaultContent();
                }
                catch (NoSuchFrameException)
                {
                    Console.WriteLine("Alert iframe not present");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"DismissAlert method threw the following excepton: {e} and stack trace {e.StackTrace}");
                }
            }            
        }
   }
