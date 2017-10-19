AgeRanger is a world leading application designed to identify person's age group!
The only problem with it is... It is not implemented - except a SQLite DB called AgeRanger.db.

To help AgeRanger to conquer the world please implement a web application that communicates with the DB mentioned above, and does the following:

 - Allows user to add a new person - every person has the first name, last name, and age;
 - Displays a list of people in the DB with their First and Last names, age and their age group. The age group should be determened based on the AgeGroup DB table - a person belongs to the age group where person's age >= 
 than group's MinAge and < than group's MaxAge. Please note that MinAge and MaxAge can be null;
 - Allows user to search for a person by his/her first or last name and displays all relevant information for the person - first and last names, age, age group.

In our fantasies AgeRanger is a single page application, and our DBA has already implied that he wants us to migrate it to SQL Server some time in the future.
And unit tests! We love unit tests!

Last, but not the least - our sales manager suggests you'll get bonus points if the application will also allow user to edit existing person records and expose a WEB API.

Please fork the project.

You are free to use any technology and frameworks you need. However if you decide to go with third party package manager or dev tool - don't forget to mention them in the README.md of your fork.

Good luck!


Age Ranger - Test Scenarios:
1. Add New Person: The objective of this test scenario is to verify that the system Allows User to add a new person:
Pre condition: Every person should have firts name, last name and an age. 

TC_1.1 - Add a new person (Authentic): The purpose of this test case if to ensure a successul entry of a new person.
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check that the webpage loads up correclty. 
> Scroll down and hit the + (Add) sign at bottom left of the page.
> Check that a form is populated on the screen with the required fields (First Name, Last name, Age, Submit, Close).
> Enter First name as desired (e.g. John).
> Enter your desired Last name (Smith).
> Enter your desired age (31).
> Hit the submit buttom & refesh the page.
> Verify that a new person (John Smith) age 31 is displayed at the bottom the list.

TC_1.2 - Add a new person (Invalid Fields): The purpose of this test case is to ensure that correct error message is displyed when User enter invalid details i.e. information in violation of business rules/functional specifications.
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check that the webpage loads up correclty. 
> Scroll down and hit the + (Add) sign at bottom left of the page.
> Check that a form is populated on the screen with the required fields (First Name, Last name, Age, Submit, Close).
> Enter First name as desired (e.g. John).
> Enter your desired Last name (Smith).
> Enter age as 99999999999999 (Invalid).
> Check that an appropirate error message (Age is invalid) appears on the screen and is highlighted in red.
> Verify that the Submit buttom is greyed out and User can't proceed with invalid details.

TC_1.3 - Add a new person (Blank Fields): The purpose of this test case is to ensure that User can't submit with blank empty fields. 
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check that the webpage loads up correclty. 
> Scroll down and hit the + (Add) sign at bottom left of the page.
> Check that a form is populated on the screen with the required fields (First Name, Last name, Age, Submit, Close).
> Leave all the fields blank and try to submit.
> Check that the Submit option is greyed out.
> User cannot submit the form when one or more fields are left blank.

2. Displays the list of people: The purpose of this test case is to verify that the system displays a list of people on the webpage with First Name, Last Name, Age and Age Group.    
Pre condition: Entries made are correct(as per business rules) and in sync with the DB table.

TC_2.1 - Display list of people on the webpage : The objective is to display a list of people in tandem with correct information.
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check the mainpage loads up correctly and displays expected information.
> Use add functionality at bottom of the page to make multiple valid entries.
> Ensure enries made are correct and reflect in the DB table. (Get command / request can be used to validate the entries made).
> Now refresh the webpage.
> Verify that the list of people is displayed with correct information.
> Check Firstname, last name, age and age group are displayed on the screen.

TC_2.1 - Age group determination - The objective is to categorize a person based on their age group (as per business rules)
> Navigate to the webpage and make a new entry.
> Enter first name as Hugo 
> Enter last name as Tester
> Enter age as 98 
> Submit the form
> Check that the Age group for Hugo Test is displayed & categorised as "Old"
> Now use the Edit functionality to change the age for Hugo Tester
> Enter age as 99 
> Hit refresh and oberve age group on the page
> Hugo Test is now categorised as "Very Old" (Business rule - Min age 99 and max age 110 is Category "Very Old")

3. Search Functionality: The objective is to Allow a user to search for a person by his/her first or last name and display all relevant information for that person.  

TC_3.1 - Search by name: System should return relevant information when searched by first or last name.
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check the mainpage loads up correctly and displays expected information.
> Navigate to the search box at top right of the screen.
> Type the text "Tester" and hit Enter.
> Check that Hugo Tester Age 98 and Under Age Group "Old" is displayed on the screen.
> Observe that the search engine is fetching relevant information.

TC_3.2 - Predictive Search: The purpose of this test case is to verify that predictive search works where applicable.
> Launch your desired browser.
> Enter the correct url (http://ageranger.azurewebsites.net/#/) and hit Enter.
> Check the mainpage loads up correctly and displays expected information.
> Navigate to the search box at top right of the screen.
> Type the text "Hu" and hit Enter.
> Check that 2 people (Hugo Tester and Huge Name) are displayed on the screen both starting with "Hu".
> Observe that Predictive search functionality works as expected & displays relevant information.

4. Edit functionality: System should allow a User to Edit an existing record.

TC_4.1 - Edit: The objective is to verify that a User can Edit an existing person.
> Navigate to the webpage.
> Pick any person (E.g. Huge Name) you wish to Edit.
> Hit the Edit button at the far right of the screen within the same line.
> Check the form appears of the page which the user can edit.
> Change Last Name for "Huge Name "to "Test" and hit Submit.
> Overve that Huge Name is now Displayed as "Huge Test".

5. Delete functionality: System should allow a User to Erase an existing record.  

TC_5.1 - Delete : The objective is to verify that a User can delete a person from the list.
> Navigate to the webpage.
> Pick any person (Alexander Maximus) from the list you wish to delele. 
> Hit the Delete buttom at extreme right within the same line.
> Refrsh the Page.
> Observe that the existing record "Alexander Maximus" is erased and No longer displayed on the screen.

                                    
                                                   API Test Cases
                                                   
1. GET Request : The purpose of this command is to fetch results for GetAllPeople

TC_1.1 - Run the GET request (Try it out) in Swagger UI to fetch your results:

[
  {
    "Id": 0,
    "FirstName": "string",
    "LastName": "string",
    "Age": 0,
    "AgeGroup": "string"
  }
]
Check the Reponse Code is 200 (OK).
Verify the results in the Response Body.
The results in the response body should match the ones on the webpage.

2. POST Request: The objective is to allow a User to add a new person to the list using a Post Command from Swagger UI.

TC_2.1 : POST (Authentic) - Add a new person using Post Request (Valid Fields)
Enter the code below and Hit "Try it out"
{
  "Id": 1886,
  "FirstName": "Alexander",
  "LastName": "Max",
  "Age": 0,
  "AgeGroup": "Toddler"
}
Check that HTTP Status Code is 204 
Verify that Alexander Max is added as a New Person

TC_2.2 : POST (Incomplete fields) - Verify that invalid fields return appripirate error message (Last Name can't be blank).
Run the code below:
{
  "Id": 1886,
  "FirstName": "Alexander",
  "LastName": "",
  "Age": 0,
  "AgeGroup": "string"
}
Check that HTTP Status Code is 500
Verify the message under Response Body "Last Name cannot be blank"

TC_2.3 : POST (Blank fields) - The purpose is to to Verify that blank fields can't be added and system returns correct error message.
Run the code below:
{
  "Id": 0,
  "FirstName": "",
  "LastName": "",
  "Age": 0,
  "AgeGroup": "string"
}
Check that the HTTP Status Code is 500
Verify the message under Response Body "First Name cannot be blank"

3. PUT Request: The objective is to verify that a User can update an existing record using PUT Command from Swagger UI.

TC_3.1 : PUT (Authentic) - Update the person (Id 1886) using PUT Request (Valid Fields)
Run the code below:
{
  "Id": 1886,
  "FirstName": "Alexander",
  "LastName": "Maximus",
  "Age": 0,
  "AgeGroup": "string"
}
Check that the HTTP Status Code is 204
Verify that Id 1886 is updated as Alexander Maximus

TC_3.2 : PUT (Invalid fields) - The purpose is to to Verify that invalid fields can't be updated and system returns correct error message.
Run the code below:
{
  "Id": 1886,
  "FirstName": "Alexander",
  "LastName": "",
  "Age": 0,
  "AgeGroup": "string"
}
Check that HTTP Status Code is 500
Verify the message under Response Body "Last Name cannot be blank"

TC_3.3 : PUT (Blank fields) - The purpose is to to Verify that existing record can't be updated with blank fields.
Run the code below:
{
  "Id": 0,
  "FirstName": "",
  "LastName": "",
  "Age": 0,
  "AgeGroup": "string"
}
Check that the HTTP Status Code is 500
Verify the message under Response Body "First Name cannot be blank"

4. DELETE Request: The objective is to verify that User can Erase an existing record Id using DELETE Command from Swagger UI

TC_4.1  - DELETE (Authentic)
> Choose the the person (Id) you wish to Delete.
> Enter the correct Id (1891 in the case) and run the command
> Check that the reponse code is 204
> Verify that Person (Ashley Turner, ID 1891) has been deleted.
> Refesh the Webpage and confirm that Person no longer exists.

TC_4.1  - DELETE (Invalid)
> Choose the the person (Id) you wish to Delete.
> Enter the already deleted Id (1891 used above) and run the command
> Check that the reponse code is 500
> Verify the error message under Response Body "unknown error Insufficient parameters supplied to the command"
> Already deleted Person cannot be erased again.

5. GET Request : The purpose of this command is to fetch all results for GetAllAgeGroups

TC_5.1 - Run the GET request (Try it out) in Swagger UI to fetch GetAllAgeGroups results: 
Run the Code below:
[
  {
    "Id": 0,
    "MinAge": 0,
    "MaxAge": 0,
    "Description": "string"
  }
]
Check that the Response Code is 200.
Verify the reults under the Response Body.
The results in the response body should match the ones on the webpage.


