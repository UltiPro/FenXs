USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_GetUserById
GO
CREATE PROCEDURE Users_GetUserById
    (
    @id INT
)
AS
BEGIN
    SELECT Id, Login, Email, Admin, FenXs_Stars
    FROM Users
    WHERE Id = @id
END