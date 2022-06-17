USE [FenXs-News]
GO
DROP PROCEDURE RemoveNews
GO
Create procedure RemoveNews
    (
    @id int
)
as
Begin
    DELETE FROM News WHERE Id = @id
End 