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
        private IWebElement AcceptCookiesButton => GetElement(By.Id("bbccookies-continue-button"));
        private IWebElement SignInLink => GetElement(By.XPath("//*[@id='idcta-link']//span[contains(text(), 'Sign in')]"));
        private IWebElement EditMySport => GetElement(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"));
        private IWebElement GetStartedButton => GetElement(By.XPath("//a[contains(text(), 'Get Started')]"));
        private IWebElement SearchTopicsBar => GetElement(By.CssSelector("input[type = 'text'][placeholder = 'Enter a sport, competition or team']"));
        public IWebElement Judo => GetElement(By.XPath("//p[contains(text(), 'Judo')]"));
        public IWebElement Formula1 => GetElement(By.XPath("//p[contains(text(), 'Formula 1')]"));
        public IWebElement SaveButton => GetElement(By.XPath("//button[(text() = 'Save changes')]"));
        public IWebElement ClearTextButton => GetElement(By.CssSelector("span[class = 'sp-c-mysport-search__icon sp-c-mysport-search__icon--reset gelicon gelicon--no']"));

        public MySportPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) { }

        public void SaveMyChanges()
        {
            FluentWaitForElementToAppear(By.XPath("//button[(text() = 'Save changes')]"), 10, 500);
            ClickElement(SaveButton);
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
            FluentWaitForElementToAppear(By.CssSelector("span[class = 'sp-c-mysport-search__icon sp-c-mysport-search__icon--reset gelicon gelicon--no']"), 10, 500);
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
            DismissAlertWithJS();
            FluentWaitForElementToAppear(By.XPath("//a[contains(text(), 'Get Started')]"), 20, 500);
            ClickElement(GetStartedButton);
        }

        public void SearchAndAddTopics()
        {
            DismissAlertWithJS();
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
            DismissAlertWithJS();
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
            DismissAlertWithJS();
            FluentWaitForElementToAppear(By.XPath("//*[@id='my-sport']//span[contains(text(), 'Edit My Sport')]"), 20, 500);
            TakeScreenshot();
            Assert.IsTrue(EditMySport.Enabled, "Edit my sport button was not enabled");
            Assert.AreEqual(PageTitle, GetPageTitle(), $"Expected PageTitle => {PageTitle}. Actual PageTitle => {GetPageTitle()}");
        }

        public void ValidateTopicsAddedHaveBeenSaved()
        {
            ValidateMyBbcSportsNewsPage();
            //TODO
            //Add validation to check that Judo and Formula1 topics are now present on my bbc sport page


        }
    }
}
