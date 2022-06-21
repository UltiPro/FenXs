DROP DATABASE [FenXs-News]
GO
CREATE DATABASE [FenXs-News]
GO
USE [FenXs-News]
GO
CREATE TABLE [News]
(
  Id INT NOT NULL IDENTITY(1,1),
  Date DATETIME NOT NULL DEFAULT GETDATE(),
  Title VARCHAR(64) NOT NULL,
  Text VARCHAR(1024) NOT NULL,
  IdOfCategory INT NOT NULL DEFAULT 0
    CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED
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