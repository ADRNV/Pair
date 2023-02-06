﻿CREATE TABLE [dbo].[InterestsPersons]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
    [PersonId] INT NULL FOREIGN KEY(PersonId) REFERENCES Persons(Id) ON DELETE CASCADE,
    [InterestId] INT NULL FOREIGN KEY(InterestId) REFERENCES Interests(Id) ON DELETE CASCADE,
    
)