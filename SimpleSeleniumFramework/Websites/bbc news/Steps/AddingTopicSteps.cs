

using OpenQA.Selenium;
using SimpleSeleniumFramework.Websites.bbc_news.Pages;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Websites.bbc_news.Steps
{
    [Binding]
    public sealed class AddingTopicSteps
    {
        private readonly MySportPage _mySportPage;
        public AddingTopicSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _mySportPage = new MySportPage(driver, scenarioContext);
        }

        [Given(@"I have signed in to my bbc sports page")]
        public void GivenIamOnBbcSportsPage()
        {
            _mySportPage.NavigateToMySportsPageAndSignIn();
        }

        [When(@"I select the option to edit my topics")]
        public void AndISelectTheOptionToEditMyTopics()
        {
            _mySportPage.EditMyTopics();
        }

        [When(@"I add new topics")]
        public void WhenIAddNewTopics()
        {
            _mySportPage.AddTopics();
        }

        [Then(@"I expect Cycling and Swimming to have all been added to my topics successfully")]
        public void ThenIExpectBbcSportsNewsContentToBeFilteredToMixedMartialArtsBoxingAndFormula1()
        {
            _mySportPage.ValidateMyBbcSportsNewsPage();
        }
    }
}
