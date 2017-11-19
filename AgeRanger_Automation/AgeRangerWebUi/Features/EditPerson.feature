Feature: EditPerson
	This feature will cover the different tests for Editing a Person to the system

@basicFlow
Scenario: EditPersonComplete
	Given I navigate to http://ageranger.azurewebsites.net
	And I edit the first Person in the list
	When I change the Age for that Person to a higher value
	And I click on Confirm
	Then the age of the first person will have changed
