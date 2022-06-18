USE [FenXs-News]
GO
DROP PROCEDURE RemoveNews
GO
CREATE PROCEDURE RemoveNews
    (
    @id INT
)
AS
BEGIN
    DELETE FROM News WHERE Id = @id
END