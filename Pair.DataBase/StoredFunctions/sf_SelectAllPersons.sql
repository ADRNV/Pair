CREATE FUNCTION [dbo].[sf_SelectAllPersons]
()
RETURNS TABLE AS RETURN
(
	SELECT * FROM Persons
)
