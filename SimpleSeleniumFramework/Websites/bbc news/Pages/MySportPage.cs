using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;
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

        public MySportPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) { }
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
    }
}
