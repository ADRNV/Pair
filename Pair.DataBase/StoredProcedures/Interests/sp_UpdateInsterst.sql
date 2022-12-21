CREATE PROCEDURE [dbo].[sp_UpdateInsterst]
	@Id int,
	@PersonId int,
	@InterestName VARCHAR(MAX)
AS
	UPDATE Interests SET PersonId = @PersonId, InterestName = @InterestName WHERE Id = @id
RETURN 0
