USE [FenXs-News]
GO
DROP PROCEDURE RemoveNews
GO
Create procedure RemoveNews
    (
    @id int
)
AS
Begin
    DELETE FROM News WHERE Id = @id
End 