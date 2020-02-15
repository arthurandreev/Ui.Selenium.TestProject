Feature: PersonalAccount
As a user, 
I want to sign into my bbc account, 
So that I can access bbc sports content personalised to me

@regression
Scenario: Sign-in to access personalised sports page
	Given I am on bbc sports page
	When I navigate to signin page
	And I enter correct username and password
	And I sign in successfully
	Then I expect bbc sports news content to be filtered to mixed martial arts, boxing and formula 1