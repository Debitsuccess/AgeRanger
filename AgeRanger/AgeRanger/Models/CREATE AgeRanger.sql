CREATE TABLE Person (
	Id INTEGER NOT NULL IDENTITY (1,1 )PRIMARY KEY,
	FirstName NVARCHAR(255),
	LastName NVARCHAR(255),
	Age	INTEGER NOT NULL
);

CREATE TABLE AgeGroup (
	Id	INTEGER NOT NULL PRIMARY KEY,
	MinAge	INTEGER NULL,
	MaxAge	INTEGER NULL,
	Description	NVARCHAR(255) NOT NULL
);

INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (1,NULL,2,'Toddler')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (2,2,14,'Child')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (3,14,20,'Teenager')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (4,20,25,'Early twenties')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (5,25,30,'Almost thirty')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (6,30,50,'Very adult')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (7,50,70,'Kinda old')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (8,70,99,'Old')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (9,99,110,'Very old')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (10,110,199,'Crazy ancient')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (11,199,4999,'Vampire')
INSERT INTO AgeGroup (Id,MinAge,MaxAge,[Description]) VALUES (12,4999,NULL,'Kauri tree')





