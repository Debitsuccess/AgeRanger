Feature: Add New Person
	This feature will cover the different tests for Adding a New Person to the system

@basicFlow
Scenario Outline: AddNewPersonComplete
	Given I navigate to http://ageranger.azurewebsites.net
	When I click on the AddPerson button
	And I add a new person with <FirstName> as a FirstName, <LastName> as a LastName and <Age> as Age
	Then I can see a new person the Landing page with <FirstName>,<LastName>,<Age> and <AgeRange>

	Examples: 
	| FirstName | LastName   | Age | AgeRange   |
	| MyName    | MyLastName | 40  | Very adult |

@exceptionFlow
Scenario Outline: AddNewPersonFail
	Given I navigate to http://ageranger.azurewebsites.net
	And I click on the AddPerson button
	When I type <something> in the First Name field
	And I clear the First Name field
	Then I can see an inline error with message <FirstNameInlineError>

	Examples:
	| something | FirstNameInlineError     |
	| something | First name is required." |