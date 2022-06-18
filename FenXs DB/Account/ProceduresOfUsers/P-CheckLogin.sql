USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_CheckLogin
GO
CREATE PROCEDURE Users_CheckLogin
    (
    @login VARCHAR(15)
)
AS
BEGIN
    SELECT Login
    FROM Account
    WHERE Login = @login
END