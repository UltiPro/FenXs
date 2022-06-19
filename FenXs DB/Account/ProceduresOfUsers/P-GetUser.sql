USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_GetUser
GO
CREATE PROCEDURE Users_GetUser
    (
    @login VARCHAR(15)
)
AS
BEGIN
    SELECT *
    FROM Users
    WHERE Login = @login
END