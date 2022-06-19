USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdateEmail
GO
CREATE PROCEDURE Users_UpdateEmail
    (
    @id INT,
    @email VARCHAR(320)
)
AS
BEGIN
    UPDATE Users SET Email = @email WHERE Id = @id
END