CREATE PROCEDURE GetIng
	@Italiano nvarchar(50)
AS
	SELECT Inglese
	FROM Country
	WHERE Italiano = @Italiano
