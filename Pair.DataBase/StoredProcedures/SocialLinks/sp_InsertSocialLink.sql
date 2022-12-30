CREATE PROCEDURE [dbo].[sp_InsertSocialLink]
	@PersonKey INT,
	@Name INT,
	@Link VARCHAR(MAX)
AS
	INSERT INTO SocialLinks VALUES(@PersonKey, @Name, @Link);
RETURN 0
