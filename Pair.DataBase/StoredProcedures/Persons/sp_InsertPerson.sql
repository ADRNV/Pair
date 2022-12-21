CREATE PROCEDURE [dbo].[sp_InsertPerson]
	@Name NVARCHAR(MAX),
	@Bio NVARCHAR(MAX),
	@Age TINYINT,
	@Sex NVARCHAR(MAX),
	@ImageUri NVARCHAR(MAX),
	@SocialCredit INT
AS
	INSERT INTO Persons VALUES(@Name, @Bio, @Age, @Sex, @ImageUri, @SocialCredit);
RETURN 0