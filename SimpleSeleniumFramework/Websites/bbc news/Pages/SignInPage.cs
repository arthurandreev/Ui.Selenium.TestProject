using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
    public class SignInPage : PageManagerFactory
    {
        private readonly string PageTitle = "BBC – Sign in";
        private readonly string Username = "testautomation1011@gmail.com";
        private readonly string Password = "ghBabcdFaq$456$";
        private IWebElement SignInButton => GetElement(By.Id("submit-button"));
        private IWebElement EmailTextBox => GetElement(By.Id("user-identifier-input"));
        private IWebElement PasswordTextBox => GetElement(By.Id("password-input"));

        public SignInPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext) { }

        public void EnterUsernameAndPassword()
        {
            DismissAlertWithJS();
            FluentWaitForElementToAppear(By.Id("submit-button"), 10, 500);
            EmailTextBox.SendKeys(Username);
            PasswordTextBox.SendKeys(Password);
        }

        public void ClickToSignin()
        {
            ClickElement(SignInButton);
            Assert.AreEqual(PageTitle, GetPageTitle());
        }
    }
}