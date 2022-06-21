USE [FenXs-News]
GO
DROP PROCEDURE GetCategories
GO
CREATE PROCEDURE GetCategories
AS
BEGIN
    SELECT *
    FROM Categories
END