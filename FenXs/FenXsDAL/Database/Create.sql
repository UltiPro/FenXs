CREATE DATABASE [FenXs]
GO
USE [FenXs]
GO
CREATE TABLE [Users]
(
    Id INT NOT NULL IDENTITY(1,1),
    Login VARCHAR(15) NOT NULL UNIQUE,
    Password VARCHAR(320) NOT NULL,
    Email VARCHAR(320) NOT NULL UNIQUE,
    Active BIT NOT NULL DEFAULT 0,
    Banned BIT NOT NULL DEFAULT 0,
    Admin BIT NOT NULL DEFAULT 0,
    Moderator BIT NOT NULL DEFAULT 0,
    FenXs_Stars INT NOT NULL DEFAULT 0,
    SignInDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastLogIn DATETIME NOT NULL DEFAULT GETDATE()
        CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE TABLE [News]
(
    Id INT NOT NULL IDENTITY(1,1),
    Date DATETIME NOT NULL DEFAULT GETDATE(),
    Title VARCHAR(64) NOT NULL,
    Text VARCHAR(1024) NOT NULL,
    IdOfCategory INT NOT NULL DEFAULT 0
        CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
INSERT INTO News
    (Title,Text,IdOfCategory)
VALUES
    ('
The News Panel has been added!', 'A news panel has been added where cumulative updates will appear.', 1)
GO
CREATE TABLE [Categories]
(
    Id INT NOT NULL IDENTITY(1,1),
    Name VARCHAR(32)
        CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
INSERT INTO Categories
    (Name)
VALUES
    ('New Content')
GO
INSERT INTO Categories
    (Name)
VALUES
    ('Update')
GO
INSERT INTO Categories
    (Name)
VALUES
    ('Correction')
GO
ALTER TABLE [News] WITH CHECK ADD CONSTRAINT [News_fk0] FOREIGN KEY ([IdOfCategory]) REFERENCES [Categories]([Id]) ON DELETE CASCADE
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