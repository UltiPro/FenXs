USE [FenXs-Account]
GO
DROP PROCEDURE CheckFreeEmail
GO
Create procedure CheckFreeEmail
(  
    @email VARCHAR(320)
)  
as   
Begin   
    SELECT email FROM Account WHERE Email = @email
End 