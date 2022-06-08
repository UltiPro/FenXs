USE [FenXs-Account]
GO
DROP PROCEDURE GetUser
GO
Create procedure GetUser
(  
    @login VARCHAR(15)
)  
as   
Begin   
    SELECT * FROM Account WHERE  Login = @login  
End 