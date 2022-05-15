Feature: PersonalAccount
As a user, 
I want to sign into my bbc account, 
So that I can personalise bbc sports content to my preference

@regression
Scenario: Sign-in to my bbc sports account
	Given I am on bbc sports page
	When I navigate to signin page
	And I enter correct username and password
	And I sign in successfully
	Then I expect to see the option to personalise my bbc sports content

@regression @AddTopicsScenario
Scenario: Add topics to my bbc sports page
    Given I have signed in to my BBC sports account
	When I start personalising my BBC sport page
	And I search and add Judo and Formula 1 topics
	And I save my changes
	Then I expect Judo and Formula 1 to have been added to my list of topics