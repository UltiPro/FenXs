USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_RemoveUser
GO
CREATE PROCEDURE Users_RemoveUser
    (
    @id INT
)
AS
BEGIN
    DELETE FROM Account WHERE Id = @id
END