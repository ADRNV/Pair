CREATE PROCEDURE [dbo].[sp_UpdatePerson]
	@Id INT,
	@Name NVARCHAR(MAX),
	@Bio NVARCHAR(MAX),
	@Age TINYINT,
	@Sex VARCHAR(MAX),
	@ImageUri VARCHAR(MAX),
	@SocialCredit INT
AS
	UPDATE Persons SET Name = @Name, Bio = @Bio, Age = @Age, Sex = @Sex, ImageUri = @ImageUri, SocialCredit = @SocialCredit WHERE Id = @id
RETURN 0
