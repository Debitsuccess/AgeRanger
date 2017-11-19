Feature: DeletePerson
	This feature will cover the different tests for Deleting a Person to the system

@basicFlow
Scenario: DeletePersonComplete
	Given I navigate to http://ageranger.azurewebsites.net
	When I delete the first Person in the list
	And I click on Confirm
	Then the count of people should decrease by one
