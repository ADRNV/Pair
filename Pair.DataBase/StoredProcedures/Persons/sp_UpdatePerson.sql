CREATE PROCEDURE [dbo].[sp_UpdatePerson]
	@Id int = 0,
	@Name VARCHAR(64),
	@Bio VARCHAR(MAX),
	@Age TINYINT,
	@Sex VARCHAR(10)
AS
	UPDATE Persons SET Name = @Name, Bio = @Bio, Age = @Age, Sex = @Sex WHERE Id = @id
RETURN 0
