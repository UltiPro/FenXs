USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_InsertUser
GO
CREATE PROCEDURE Users_InsertUser
    (
    @login VARCHAR(15),
    @password VARCHAR(320),
    @email VARCHAR(320)
)
AS
BEGIN
    INSERT INTO Users
        (Login,Password,Email)
    Values
        (@login, @password, @email)
END