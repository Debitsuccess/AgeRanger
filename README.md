Hi

I decided to go with the following technology choices. It would have been easier for me to do this in Knockout and JQuery, 
but I really wanted to give it ago with ReactJS, webpack etc. 

	1 - Visual Studio 2017 (C#, MVC, WebApi)
	2 - Typescript
	3 - Installed via NodeJS
			Webpack
			ReactJS and React-dom typings
			Awesome Typescript Loader
		

Notes
	1 - I couldn't get a driver for SQLite for VS 2017, so couldn't get a data-source to appear for Entity FrameWork (gutted).
		I tried quite a few old drivers but none of them were up to the task. Other wise I would have used Entity Framework
		with a nice Repository and Unit of Work pattern.
		
	2 - I wanted to get this back to you today, so did not bring in Ninject(IOC) for the controller. I did however make them async, and use interfaces.
		So would be easier to implement IOC from here.
		
	3 - I have never used SQLlite before, just standard Sql Server. So just added this DB into a file in the project. Not happy about the way I accessed
		this via "HostingEnvironment.MapPath" rather than a config setting.  Which leads to my next comment....
		
	4 - I did a couple of basic unit tests that will require the code in the "RepositoryBase : GetServerPath()" to be un-commented to access the
		correct Database path for the Unit tests to pass.
		
	5 - I also didn't go crazy with user feedback, only implemented the basic validation for adding a user. 
	
	6 - I implemented everything in the specifications so it should all run. I enjoyed the opportunity to do an architectural spike in ReactJS here,
		and will use what I have learned here to move forward and continue learning.
		
Kind regards

Joel Belling