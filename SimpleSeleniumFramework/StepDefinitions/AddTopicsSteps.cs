using OpenQA.Selenium;
using SimpleSeleniumFramework.POMs;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.StepDefinitions
{
    [Binding]
    public sealed class AddTopicsSteps
    {
        private readonly MySportPage _mySportPage;
        private readonly SignInPage _signInPage;
        public AddTopicsSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _mySportPage = new MySportPage(driver, scenarioContext);
            _signInPage = new SignInPage(driver, scenarioContext);
        }

        [Given(@"I have signed in to my BBC sports account")]
        public void GivenIHaveSignedInToMyBBCSportsAccount()
        {
            _mySportPage.NavigateToMySportPage();
            _mySportPage.NavigateToSigninPage();
            _signInPage.EnterUsernameAndPassword();
            _signInPage.SignIn();
        }

        [When(@"I start personalising my BBC sport page")]
        public void AndIPersonaliseMyBBCSportPage()
        {
            _mySportPage.StartPersonalisingMySportPage();
        }

        [When(@"I search and add Judo and Formula 1 topics")]
        public void AndISearchAndAddJudoAndFormula1Topics()
        {
            _mySportPage.SearchAndAddTopics();
        }

        [When(@"I save my changes")]
        public void AndISaveMyChanges()
        {
            _mySportPage.SaveMyChanges();
            _mySportPage.WaitForSavedChangesToastToAppear();
        }

        [Then(@"I expect Judo and Formula 1 to have been added to my list of topics")]
        public void ThenIExpectJudoAndFormula1ToHaveBeenAddedToMyListOfTopics()
        {
            _mySportPage.ValidateTopicsAddedHaveBeenSaved();
        }
    }
}
