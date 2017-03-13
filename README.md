Pre-requisites

* Windows 
* .Net 4.5.2 Framework
* Visual Studio Professional 2015 **OR** Visual Studio Community 2015
  with Extensions (from Tools > Extensions and Updates:
	- NuGet Package Manager (3.4)
	
* SQL Server 2014 -+ with Tools (with SQL Server Management Studio) - Express works
* IIS Express (8.0) - install via the "Web Platform"

* NuGet Packages
-AutoFac for depedency Injection
-EntityFramework ORM
-Moq in unit testing

* FrontEnd-AgeRanger-Client
-Angular 1.4


* SetUp Database
-I have migrated SQLite AgeRanger.db to a AgeRangerDBScript.sql which is in the project directory. Please run the script on Sql Server.
-It will create AgeRanger database with Person and AgeGroup table.
-It will populate the exiting AgeGroup data from Sqlite db in AgeGroup table.
-It will also add a new column in Person table called AgeGroupId which is foreign key and reference to AgeGroup.Id Primary key.
-Please run the below query anytime on db to get all person details i.e. FirstName, LastName, Age, AgeGroup

SELECT 
 p.FirstName,
 p.LastName, 
 p.Age,
 a.Description
 FROM Person p
INNER JOIN AgeGroup a ON p.AgeGroupId = a.Id

* SetUp And Start WebAPI
-There is a AgeRanger.sln file in project directory. double click it to open in visual studio.
-Right click on Solution folder in visual studio select Rebuild Solution or (Clean and then Build Solution).
-Right click on AgeRangerTest project in visual studio select Run Unit Tests.
-Right click on AgeRanger project And Select Set as StartUp Project.
-Run the project(WebAPI) and do not stop it.
-Project(WebAPI) is running on default port 65117(http://localhost:65117/)this url is harded coded in client to communicate with API.

* SetUp AgeRangerClient in IIS
-Double click on client folder in project directory and copy the path(location).
-Open IIS Right click on the `Sites` folder > AddWebsite 
	-Enter a preferred name e.g. ageranger in site name text box
	-Paste the copied path in Physical path text box
	-Enter the preferred host name e.g. ageranger.localhost in Host name textbox.
	-Click Ok
	-Goto C:\Windows\System32\drivers\etc folder, open the host file in notepad++ as an administrator
	-Paste 127.0.0.1 ageranger.localhost. make sure to change the host name if you have provided anything else in IIS host name.
	
* Goto browser enter the url host name you have provided in host file and IIS e.g. ageranger.localhost
* Default page is set to {hostname}#/people which is displaying the list of people from db.
* Navigate 


