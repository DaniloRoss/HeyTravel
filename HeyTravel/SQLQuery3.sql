CREATE PROCEDURE GetIta
	@Inglese nvarchar(50)
AS
	SELECT Italiano
	FROM Country
	WHERE Inglese = @Inglese