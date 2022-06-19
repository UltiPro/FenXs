USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_CheckEmail
GO
CREATE PROCEDURE Users_CheckEmail
    (
    @email VARCHAR(320)
)
AS
BEGIN
    SELECT Email
    FROM Users
    WHERE Email = @email
End