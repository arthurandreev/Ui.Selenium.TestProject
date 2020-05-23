using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;
using System;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
    public class MySportPage : PageManagerFactory
    {
        private readonly string Url = "https://www.bbc.co.uk/sport/my-sport";
        private readonly string PageTitle = "My Sport - Create your own personal BBC My Sport page";
        private IWebElement OkCookiesButton => GetElement(By.Id("bbcprivacy-continue-button"));
        private IWebElement SavedChangesToast => GetElement(By.XPath("//p[(text() = 'Your changes have been saved.')]"));
        private IWebElement AcceptCookiesButton => GetElement(By.Id("bbccookies-continue-button"));
        private IWebElement SignInLink => GetElement(By.XPath("//*[@id='idcta-link']//span[contains(text(), 'Sign in')]"));
        private IWebElement EditMySport => GetElement(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"));
        private IWebElement GetStartedButton => GetElement(By.XPath("//a[contains(text(), 'Get Started')]"));
        private IWebElement SearchTopicsBar => GetElement(By.CssSelector("input[type = 'text'][placeholder = 'Enter a sport, competition or team']"));
        private IWebElement Judo => GetElement(By.XPath("//p[contains(text(), 'Judo')]"));
        private IWebElement Formula1 => GetElement(By.XPath("//p[contains(text(), 'Formula 1')]"));
        private IWebElement SaveButton => GetElement(By.XPath("//button[(text() = 'Save changes')]"));
        private IWebElement ClearTextButton => GetElement(By.CssSelector("span[aria-role = 'hidden']"));
        private IWebElement JudoNewsSection => GetElement(By.CssSelector("a[href = '/sport/judo']"));
        private IWebElement Formula1NewsSection => GetElement(By.XPath("//*[@class='component twickenham']//a[@href='/sport/formula1']//span[contains(text(), 'Formula 1')]"));
        public MySportPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) { }

        public void SaveMyChanges()
        {
            FluentWaitForElementToAppear(By.XPath("//button[(text() = 'Save changes')]"), 10, 500);
            ClickElement(SaveButton);
        }

        public void WaitForSavedChangesToastToAppear()
        {
            FluentWaitForElementToAppear(By.XPath("//p[(text() = 'Your changes have been saved.')]"), 10, 500);
            Assert.IsTrue(SavedChangesToast.Displayed, "Your changes have been saved toast was not displayed");
        }

        public void RemoveTopics()
        {
            FluentWaitForElementToAppear(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"), 10, 500);
            EditMySport.Click();
            FluentWaitForElementToAppear(By.XPath("//p[contains(text(), 'Formula 1')]"), 10, 500);
            Formula1.Click();
            FluentWaitForElementToAppear(By.XPath("//p[contains(text(), 'Judo')]"), 10, 500);
            Judo.Click();
        }

        public void SearchAndAddFormula1()
        {
            SearchTopicsBar.SendKeys("Formula");
            SearchTopicsBar.SendKeys(Keys.Space);
            SearchTopicsBar.SendKeys("1");
            FluentWaitForElementToAppear(By.XPath("//p[contains(text(), 'Formula 1')]"), 10, 500);
            ClickElement(Formula1);
        }

        public void ClearSeartTopicsBar()
        {
            FluentWaitForElementToAppear(By.CssSelector("span[aria-role = 'hidden']"), 10, 500);
            ClickElement(ClearTextButton);
        }

        public void SearchAndAddJudo()
        {
            SearchTopicsBar.SendKeys("Judo");
            FluentWaitForElementToAppear(By.XPath("//p[contains(text(), 'Judo')]"), 10, 500);
            ClickElement(Judo);
        }

        public void StartPersonalisingMySportPage()
        {
            FluentWaitForElementToAppear(By.XPath("//a[contains(text(), 'Get Started')]"), 20, 500);
            ClickElement(GetStartedButton);
        }

        public void SearchAndAddTopics()
        {
            FluentWaitForElementToAppear(By.CssSelector("input[type = 'text'][placeholder = 'Enter a sport, competition or team']"), 20, 500);
            SearchAndAddFormula1();
            ClearSeartTopicsBar();
            SearchAndAddJudo();        
        }

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
            AcceptCookies();
            Assert.AreEqual(Url, GetUrl(), $"Expected Url => {Url}. Actual Url => {GetUrl()}");
            Assert.AreEqual(PageTitle, GetPageTitle(), $"Expected PageTitle => {PageTitle}. Actual PageTitle => {GetPageTitle()}");
        }

        public void NavigateToSigninPage()
        {
            FluentWaitForElementToAppear(By.XPath("//*[contains(text(), 'Sign in')]"), 10, 500);
            ClickElement(SignInLink);
        }

        public void ValidateMyBbcSportsNewsPage()
        {
            FluentWaitForElementToAppear(By.XPath("//a[contains(text(), 'Get Started')]"), 20, 500);
            Assert.IsTrue(GetStartedButton.Enabled);
            Assert.AreEqual(PageTitle, GetPageTitle(), $"Expected PageTitle => {PageTitle}. Actual PageTitle => {GetPageTitle()}");
            TakeScreenshot();
        }

        public void ValidateTopicsAddedHaveBeenSaved()
        {
            FluentWaitForElementToAppear(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"), 10, 500);
            Assert.IsTrue(EditMySport.Enabled, "Edit my sport button did not appear on the page");
            Assert.IsTrue(JudoNewsSection.Enabled, "Judo news section did not appear on the page");
            Assert.IsTrue(Formula1NewsSection.Enabled, "Formula 1 news section did not appear on the page");
            TakeScreenshot();
        }
    }
}
