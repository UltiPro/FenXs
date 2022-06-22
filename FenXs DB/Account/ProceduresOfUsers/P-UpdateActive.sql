USE [FenXs-Accounts]
GO
DROP PROCEDURE Users_UpdateActive
GO
CREATE PROCEDURE Users_UpdateActive
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Active = @set WHERE Id = @id
END