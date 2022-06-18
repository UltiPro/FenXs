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
  Text VARCHAR(1024) NOT NULL
    CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
INSERT INTO News
  (Title,Text)
VALUES
  ('
The News Panel has been added!', 'A news panel has been added where cumulative updates will appear.')