﻿CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(MAX),
	[Bio] NVARCHAR(MAX),
	[Age] INT NOT NULL,
	[Sex] NVARCHAR(MAX),
	[SocialCredit] INT,
)
