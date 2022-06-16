DROP DATABASE [FenXs-News]
GO
CREATE DATABASE [FenXs-News]
GO
USE [FenXs-News]
GO
CREATE TABLE [News]
(
  Id int NOT NULL IDENTITY(1,1),
  Date datetime NOT NULL DEFAULT getdate(),
  Title varchar(64) NOT NULL,
  Text varchar(1024) NOT NULL
    CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)