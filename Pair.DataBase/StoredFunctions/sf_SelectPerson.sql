CREATE FUNCTION [dbo].[sf_SelectPerson]
(
	@Id INT
)
RETURNS TABLE AS RETURN
(
	SELECT * FROM Persons WHERE Id = @Id
)
