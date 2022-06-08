USE [FenXs-Account]
GO
DROP PROCEDURE CheckFreeLogin
GO
Create procedure CheckFreeLogin
(  
    @login VARCHAR(15)
)  
as   
Begin   
    SELECT login FROM Account WHERE Login = @login 
End 
