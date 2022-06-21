USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_GetAllUsers
GO
CREATE PROCEDURE Users_GetAllUsers
AS
BEGIN
    SELECT *
    FROM Users
END