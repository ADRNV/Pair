CREATE PROCEDURE [dbo].[sp_InsertPerson]
	@Name VARCHAR(64),
	@Bio NVARCHAR(MAX),
	@Age TINYINT,
	@Sex NVARCHAR(10)
AS
	INSERT INTO Persons VALUES(@Name, @Bio, @Age, @Sex);
RETURN 0
