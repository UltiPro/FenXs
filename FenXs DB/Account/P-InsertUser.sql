USE [FenXs-Account]
GO
DROP PROCEDURE InsertUser
GO
Create procedure InsertUser
(  
    @login VARCHAR(15),
    @password VARCHAR(320),
    @email VARCHAR(320)
)  
as   
Begin   
    Insert into Account(Login,Password,Email)   
    Values (@login,@password,@email)   
End 