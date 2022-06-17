USE [FenXs-Account]
GO
DROP PROCEDURE UpdateAdmin
GO
Create procedure UpdateAdmin
    (
    @id int
)
as
Begin
    UPDATE Account SET Admin = 1 WHERE Id = @id
End 