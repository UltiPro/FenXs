USE [FenXs-Account]
GO
DROP PROCEDURE UpdateEmail
GO
Create procedure UpdateEmail
    (
    @id int,
    @email VARCHAR(320)
)
as
Begin
    UPDATE Account SET Email = @email WHERE Id = @id
End 