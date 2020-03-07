using OpenQA.Selenium;
using SimpleSeleniumFramework.Websites.bbc_news.Pages;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Steps
{
    [Binding]
    public sealed class SigninSteps
    {
        private readonly MySportPage _mySportPage;
        public SigninSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _mySportPage = new MySportPage(driver, scenarioContext);
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

        [Then(@"I expect to see the option to personalise my bbc sports topics")]
        public void ThenIExpectToSeeTheOptionToPersonaliseMyBbcSportsTopics()
        {
            _mySportPage.ValidateMyBbcSportsNewsPage();
        }
    }
}
