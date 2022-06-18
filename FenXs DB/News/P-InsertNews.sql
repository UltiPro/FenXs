USE [FenXs-News]
GO
DROP PROCEDURE InsertNews
GO
CREATE PROCEDURE InsertNews
    (
    @title VARCHAR(64),
    @text VARCHAR(1024)
)
AS
BEGIN
    INSERT INTO News
        (Title,Text)
    VALUES
        (@title, @text)
END