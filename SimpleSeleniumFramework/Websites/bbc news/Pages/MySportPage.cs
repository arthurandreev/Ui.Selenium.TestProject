using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSeleniumFramework.Websites.bbc_news.Pages
{
   public class MySportPage : PageManagerFactory
    {
        private readonly string Url = "https://www.bbc.co.uk/sport/my-sport";
        private readonly string Username = "arthur.andreev21@gmail.com";
        private readonly string Password = "&n7cLffsuRdH7hJ";

        private IWebElement CookiesYesIAgreeButton => GetElement(By.Id("bbccookies-continue-button"));
        private IWebElement SignInButtonOnMainPage => GetElement(By.XPath("//*[contains(text(), 'Sign in')]"));
        private IWebElement SignInButtonOnSigninPage => GetElement(By.Id("submit-button"));
        private IWebElement EmailTextBox => GetElement(By.Id("user-identifier-input"));
        private IWebElement PasswordTextBox => GetElement(By.Id("password-input"));

        public MySportPage(IWebDriver driver) : base(driver)
        {

        }
        public void NavigateToMySportPage()
        {
            GoToUrl(Url);
            Thread.Sleep(5000);
        }

        public void NavigateToSigninPage()
        {
            Thread.Sleep(5000);
            ClickElement(SignInButtonOnMainPage);
            Thread.Sleep(5000);
        }

        public void EnterUsernameAndPassword()
        {
           Thread.Sleep(2500);
           EmailTextBox.SendKeys(Username);
           Thread.Sleep(2500);
           PasswordTextBox.SendKeys(Password);
        }

        public void ClickToSignin()
        {
            Thread.Sleep(2000);
            ClickElement(SignInButtonOnSigninPage);
        }

        public void ValidateNewsContent()
        {
            Thread.Sleep(25000);
            ClickElement(CookiesYesIAgreeButton);
        }
    }
}
