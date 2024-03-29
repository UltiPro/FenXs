USE [FenXs]
GO
CREATE TABLE [Minecraft]
(
    Id INT NOT NULL IDENTITY(1,1),
    IdOfAdmin INT NOT NULL,
    ConsoleCode INT NOT NULL,
    Active BIT NOT NULL DEFAULT 0,
    Description VARCHAR(1024),
    LastLive DATETIME NOT NULL DEFAULT GETDATE()
        CONSTRAINT [PK_Minecraft] PRIMARY KEY CLUSTERED
  (
    [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
ALTER TABLE [Minecraft] WITH CHECK ADD CONSTRAINT [Minecraft_fk0] FOREIGN KEY ([IdOfAdmin]) REFERENCES [Users]([Id])