USE [FenXs-News]
GO
DROP PROCEDURE UpdateNews
GO
Create procedure UpdateNews
    (
    @id int,
    @title varchar(64),
    @text varchar(1024)
)
AS
Begin
    UPDATE News SET Title = @title, Text = @text WHERE Id = @id;
End 