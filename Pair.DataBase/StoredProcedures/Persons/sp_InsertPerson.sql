CREATE PROCEDURE [dbo].[sp_InsertPerson]
	@Name VARCHAR(64),
	@Age TINYINT,
	@Sex VARCHAR(10)
AS
	INSERT INTO Persons VALUES(@Name, @Age, @Sex);
RETURN 0
