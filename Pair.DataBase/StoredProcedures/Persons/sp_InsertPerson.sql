CREATE PROCEDURE [dbo].[sp_InsertPerson]
	@Name VARCHAR(64),
	@Bio VARCHAR(MAX),
	@Age TINYINT,
	@Sex VARCHAR(10)
AS
	INSERT INTO Persons VALUES(@Name, @Bio, @Age, @Sex);
RETURN 0
