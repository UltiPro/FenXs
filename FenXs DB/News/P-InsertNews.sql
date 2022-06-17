USE [FenXs-News]
GO
DROP PROCEDURE InsertNews
GO
Create procedure InsertNews
    (
    @title VARCHAR(64),
    @text VARCHAR(1024)
)
AS
Begin
    Insert into News
        (Title,Text)
    Values
        (@title, @text);
End 