USE [FenXs-News]
GO
DROP PROCEDURE UpdateNews
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