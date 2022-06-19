USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdateAdmin
GO
CREATE PROCEDURE Users_UpdateAdmin
    (
    @id INT
)
AS
BEGIN
    UPDATE Users SET Admin = 1 WHERE Id = @id
END