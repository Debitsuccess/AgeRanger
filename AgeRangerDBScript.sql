IF db_id('AgeRanger') IS NULL 
    CREATE DATABASE AgeRanger;
GO

USE AgeRanger;
GO

CREATE TABLE [dbo].[AgeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinAge] [int] NULL,
	[MaxAge] [int] NULL,
	[Description] [varchar](max) NOT NULL,

PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[LastName] [varchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[AgeGroupId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT INTO AgeGroup (MinAge,MaxAge,Description) 
VALUES 
 (NULL,2,'Toddler'),
 (2,14,'Child'),
 (14,20,'Teenager'),
 (20,25,'Early twenties'),
 (25,30,'Almost thirty'),
 (30,50,'Very adult'),
 (50,70,'Kinda old'),
 (70,99,'Old'),
 (99,110,'Very old'),
 (110,199,'Crazy ancient'),
 (199,4999,'Vampire'),
 (4999,NULL,'Kauri tree');
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_AgeGroup] FOREIGN KEY([AgeGroupId])
REFERENCES [dbo].[AgeGroup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_AgeGroup]
GO
