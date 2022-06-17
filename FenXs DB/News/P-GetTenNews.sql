USE [FenXs-News]
GO
DROP PROCEDURE GetTenNews
GO
Create procedure GetTenNews
AS
Begin
    SELECT TOP 10
        *
    FROM News
    ORDER BY Date DESC;
End 