CREATE PROCEDURE [dbo].[sp_UpdateSocialLink]
	@Id int = 0,
	@PersonId INT,
	@Name VARCHAR(64),
	@Link VARCHAR(255)
AS
	UPDATE SocialLinks SET Name = @Name, Link = @Link, PersonId = @PersonId WHERE Id = @id;
RETURN 0
