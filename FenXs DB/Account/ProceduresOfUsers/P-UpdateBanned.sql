USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdateBanned
GO
CREATE PROCEDURE Users_UpdateBanned
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Banned = @set WHERE Id = @id
END