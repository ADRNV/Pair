CREATE PROCEDURE [dbo].[sp_InsertInterest]
	@PersonId int,
	@InterestName int
AS
	INSERT Interests VALUES(@PersonId, @InterestName);
RETURN 0
