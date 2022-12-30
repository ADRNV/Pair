CREATE PROCEDURE [dbo].[sp_UpdatePerson]
	@Id int = 0,
	@Name NVARCHAR(MAX),
	@Bio NVARCHAR(MAX),
	@Age TINYINT,
	@Sex VARCHAR(10)
AS
	UPDATE Persons SET Name = @Name, Bio = @Bio, Age = @Age, Sex = @Sex WHERE Id = @id
RETURN 0
