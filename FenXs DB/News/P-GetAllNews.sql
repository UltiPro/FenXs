USE [FenXs-News]
GO
DROP PROCEDURE GetAllNews
GO
Create procedure GetAllNews
as
Begin
    SELECT *
    FROM News
    ORDER BY Date DESC;
End 