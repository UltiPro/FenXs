USE [FenXs-News]
GO
DROP PROCEDURE InsertNews
GO
CREATE PROCEDURE InsertNews
    (
    @title VARCHAR(64),
    @text VARCHAR(1024),
    @idOfCategory INT
)
AS
BEGIN
    INSERT INTO News
        (Title,Text,IdOfCategory)
    VALUES
        (@title, @text, @idOfCategory)
END