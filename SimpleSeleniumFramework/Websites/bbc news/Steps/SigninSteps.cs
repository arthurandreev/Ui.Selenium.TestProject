using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Websites.bbc_news.Pages;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Steps
{
    [Binding]
    public sealed class SigninSteps
    {

        private readonly MySportPage _mySportPage;

        public SigninSteps(IWebDriver driver)
        {
            _mySportPage = new MySportPage(driver);
        }

        [Given(@"I am on bbc sports page")]
        public void GivenIamOnBbcSportsPage()
        {
            _mySportPage.NavigateToMySportPage();
        }

        [When(@"I navigate to signin page")]
        public void WhenINavigateToSigninPage()
        {
            _mySportPage.NavigateToSigninPage();
        }

        [When(@"I enter correct username and password")]
        public void AndEnterCorrectUsernameAndPassword()
        {
            _mySportPage.EnterUsernameAndPassword();
        }

        [When(@"I sign in successfully")]
        public void AndISignInSuccessfully()
        {
            _mySportPage.ClickToSignin();
        }

        [Then(@"I expect bbc sports news content to be filtered to mixed martial arts, boxing and formula 1")]
        public void ThenIExpectBbcSportsNewsContentToBeFilteredToMixedMartialArtsBoxingAndFormula1()
        {
            _mySportPage.ValidateNewsContent();
        }
    }
}
