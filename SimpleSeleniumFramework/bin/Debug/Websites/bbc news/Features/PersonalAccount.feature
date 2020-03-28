Feature: PersonalAccount
As a user, 
I want to sign into my bbc account, 
So that I can view bbc sports content personalised to me

@regression
Scenario: Sign-in to access my bbc sports page
	Given I am on bbc sports page
	When I navigate to signin page
	And I enter correct username and password
	And I sign in successfully
	Then I expect my bbc sports news to enable me to edit my topic selection

@regression
Scenario: Adding topics to my bbc sports page
    Given I have signed in to my bbc sports page
	When I select the option to edit my topics
	And I add new topics
	Then I expect Cycling and Swimming to have all been added to my topics successfully