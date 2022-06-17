USE [FenXs-Account]
GO
DROP PROCEDURE UpdatePassword
GO
Create procedure UpdatePassword
    (
    @id int,
    @password VARCHAR(320)
)
as
Begin
    UPDATE Account SET Password = @password WHERE Id = @id
End 