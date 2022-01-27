CREATE PROCEDURE InsertCoutry
    @Italiano nvarchar(50),   
    @Inglese nvarchar(50)   
AS
    INSERT INTO Country (Italiano, Inglese)
    VALUES (@Italiano, @Inglese);