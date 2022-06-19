USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdatePassword
GO
CREATE PROCEDURE Users_UpdatePassword
    (
    @id INT,
    @password VARCHAR(320)
)
AS
BEGIN
    UPDATE Users SET Password = @password WHERE Id = @id
END