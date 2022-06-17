USE [FenXs-News]
GO
DROP PROCEDURE GetAllNews
GO
Create procedure GetAllNews
AS
Begin
    SELECT *
    FROM News
    ORDER BY Date DESC;
End 