USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdateAdmin
GO
CREATE PROCEDURE Users_UpdateAdmin
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Admin = @set WHERE Id = @id
END