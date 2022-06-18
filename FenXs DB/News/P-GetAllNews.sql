USE [FenXs-News]
GO
DROP PROCEDURE GetAllNews
GO
Create procedure GetAllNews
AS
BEGIN
    SELECT *
    FROM News
    ORDER BY Date DESC
END