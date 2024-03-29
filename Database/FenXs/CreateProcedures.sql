USE [FenXs]
GO
CREATE PROCEDURE Users_InsertUser
    (
    @login VARCHAR(15),
    @password VARCHAR(320),
    @email VARCHAR(320)
)
AS
BEGIN
    INSERT INTO Users
        (Login,Password,Email)
    Values
        (@login, @password, @email)
END
GO
CREATE PROCEDURE Users_CheckEmail
    (
    @email VARCHAR(320)
)
AS
BEGIN
    SELECT Email
    FROM Users
    WHERE Email = @email
End
GO
CREATE PROCEDURE Users_CheckLogin
    (
    @login VARCHAR(15)
)
AS
BEGIN
    SELECT Login
    FROM Users
    WHERE Login = @login
END
GO
CREATE PROCEDURE Users_GetUser
    (
    @login VARCHAR(15)
)
AS
BEGIN
    SELECT *
    FROM Users
    WHERE Login = @login
END
GO
CREATE PROCEDURE Users_GetUserById
    (
    @id INT
)
AS
BEGIN
    SELECT Id, Login, Email, Admin, FenXs_Stars
    FROM Users
    WHERE Id = @id
END
GO
CREATE PROCEDURE Users_GetAllUsers
AS
BEGIN
    SELECT *
    FROM Users
END
GO
CREATE PROCEDURE Users_GetPassword
    (
    @id INT
)
AS
BEGIN
    SELECT Password
    FROM Users
    WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdateEmail
    (
    @id INT,
    @email VARCHAR(320)
)
AS
BEGIN
    UPDATE Users SET Email = @email WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdatePassword
    (
    @id INT,
    @password VARCHAR(320)
)
AS
BEGIN
    UPDATE Users SET Password = @password WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdateAdmin
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Admin = @set WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdateBanned
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Banned = @set WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdateActive
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Active = @set WHERE Id = @id
END
GO
CREATE PROCEDURE Users_UpdateModerator
    (
    @id INT,
    @set BIT
)
AS
BEGIN
    UPDATE Users SET Moderator = @set WHERE Id = @id
END
GO
CREATE PROCEDURE Users_RemoveUser
    (
    @id INT
)
AS
BEGIN
    DELETE FROM Users WHERE Id = @id
END
GO
CREATE PROCEDURE GetAllNews
AS
BEGIN
    SELECT *
    FROM News
    ORDER BY Date DESC
END
GO
CREATE PROCEDURE GetCategories
AS
BEGIN
    SELECT *
    FROM Categories
END
GO
CREATE PROCEDURE GetTenNews
AS
BEGIN
    SELECT TOP 10
        *
    FROM News
    ORDER BY Date DESC
END
GO
CREATE PROCEDURE InsertNews
    (
    @title VARCHAR(64),
    @text VARCHAR(1024),
    @idOfCategory INT
)
AS
BEGIN
    INSERT INTO News
        (Title,Text,IdOfCategory)
    VALUES
        (@title, @text, @idOfCategory)
END
GO
CREATE PROCEDURE RemoveNews
    (
    @id INT
)
AS
BEGIN
    DELETE FROM News WHERE Id = @id
END
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