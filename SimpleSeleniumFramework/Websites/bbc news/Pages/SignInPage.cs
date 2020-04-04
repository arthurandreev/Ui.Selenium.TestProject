using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
    public class SignInPage : PageManagerFactory
    {
        private readonly string PageTitle = "BBC – Sign in";
        private IWebElement SignInButton => GetElement(By.Id("submit-button"));
        private IWebElement EmailTextBox => GetElement(By.Id("user-identifier-input"));
        private IWebElement PasswordTextBox => GetElement(By.Id("password-input"));

        private readonly TestUser TestUser = new TestUser();
        public SignInPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) 
        {
        }

        public void EnterUsernameAndPassword()
        {
            FluentWaitForElementToAppear(By.Id("submit-button"), 10, 500);
            EmailTextBox.SendKeys(TestUser.Email);
            PasswordTextBox.SendKeys(TestUser.Password);
            Assert.AreEqual(PageTitle, GetPageTitle(), $"Expected PageTitle => {PageTitle}. Actual PageTitle => {GetPageTitle()}");
        }
        public void SignIn()
        {
            ClickElement(SignInButton);          
        }
    }
}