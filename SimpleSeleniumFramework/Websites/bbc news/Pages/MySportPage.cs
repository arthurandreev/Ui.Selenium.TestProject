using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.TestFramework;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
   public class MySportPage : PageManagerFactory
    {
        private readonly string Url = "https://www.bbc.co.uk/sport/my-sport";
        private readonly string Username = "testautomation1011@gmail.com";
        private readonly string Password = "ghBabcdFaq$456$";
        private IWebElement MyAccountButton => GetElement(By.Id("idcta-link"));
        private IWebElement SignInButtonOnMainPage => GetElement(By.XPath("//*[contains(text(), 'Sign in')]"));
        private IWebElement SignInButtonOnSigninPage => GetElement(By.Id("submit-button"));
        private IWebElement EmailTextBox => GetElement(By.Id("user-identifier-input"));
        private IWebElement PasswordTextBox => GetElement(By.Id("password-input"));
        private IWebElement MixedMartialArtsTopic => GetElement(By.XPath("//*[contains(text(), 'Mixed Martial Arts')]"));
        private IWebElement BoxingTopic => GetElement(By.XPath("//*[contains(text(), 'Boxing')]"));
        private IWebElement Formula1Topic => GetElement(By.XPath("//*[contains(text(), 'Formula 1')]"));
        private IWebElement EditMySportButton => GetElement(By.XPath("//*[contains(text(), 'Edit My Sport')]"));
       
        public MySportPage(IWebDriver driver) : base(driver)
        {

        }
        public void NavigateToMySportPage()
        {
            GoToUrl(Url);
        }

        public void NavigateToSigninPage()
        {
            ClickElement(SignInButtonOnMainPage);
        }

        public void EnterUsernameAndPassword()
        {
           EmailTextBox.SendKeys(Username);
           PasswordTextBox.SendKeys(Password);
        }

        public void ClickToSignin()
        {
            ClickElement(SignInButtonOnSigninPage);
        }

        public void ValidateNewsContent()
        {
            WaitforElementToBeClickable(MyAccountButton, 10);
            WaitforElementToBeClickable(EditMySportButton, 10);
            Assert.IsTrue(MixedMartialArtsTopic.Enabled);
            Assert.IsTrue(BoxingTopic.Enabled); 
            Assert.IsTrue(Formula1Topic.Enabled);
        }
    }
}
