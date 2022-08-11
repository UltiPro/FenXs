USE [FenXs-News]
GO
CREATE PROCEDURE GetAllNews
AS
BEGIN
    SELECT *
    FROM News
    ORDER BY Date DESC
END
GO
CREATE PROCEDURE GetCategories
AS
BEGIN
    SELECT *
    FROM Categories
END
GO
CREATE PROCEDURE GetTenNews
AS
BEGIN
    SELECT TOP 10
        *
    FROM News
    ORDER BY Date DESC
END
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
GO
CREATE PROCEDURE RemoveNews
    (
    @id INT
)
AS
BEGIN
    DELETE FROM News WHERE Id = @id
END
GO
CREATE PROCEDURE UpdateNews
    (
    @id INT,
    @title VARCHAR(64),
    @text VARCHAR(1024),
    @idOfCategory INT
)
AS
BEGIN
    UPDATE News SET Title = @title, Text = @text, IdOfCategory = @idOfCategory WHERE Id = @id
END