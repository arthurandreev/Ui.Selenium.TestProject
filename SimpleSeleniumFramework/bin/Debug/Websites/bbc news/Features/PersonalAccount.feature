Feature: PersonalAccount
As a user, 
I want to sign into my bbc account, 
So that I can personalise bbc sports content to my preference

@regression
Scenario: Sign-in to access personalised sports page
	Given I am on bbc sports page
	When I navigate to signin page
	And I enter correct username and password
	And I sign in successfully
	Then I expect to see the option to personalise my bbc sports content