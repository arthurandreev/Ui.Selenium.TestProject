using OpenQA.Selenium;
using SimpleSeleniumFramework.POMs;
using System;
using TechTalk.SpecFlow;

namespace SimpleSeleniumFramework.Hooks
{
    [Binding]
    public class AddTopicsScenarioTearDown
    {
        private readonly MySportPage _mySportPage;
        public AddTopicsScenarioTearDown(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _mySportPage = new MySportPage(driver, scenarioContext);
        }
        [AfterScenario(Order = 1)]
        [Scope(Tag = "AddTopicsScenario")]
        public void TearDown()
        {
            _mySportPage.RemoveTopics();
            _mySportPage.SaveMyChanges();
        }
    }
}
