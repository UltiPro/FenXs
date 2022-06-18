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
    FROM Account
    WHERE Login = @login
END