USE Roulette_Test

CREATE TABLE [Roulettes]
(
[Id] INT IDENTITY(1,1),
[IsOpen] BIT NOT NULL DEFAULT 0,
[BetResult] INT DEFAULT 0,
CONSTRAINT PK_Roulette PRIMARY KEY (Id),
);

CREATE TABLE [Users]
(
[Id] INT IDENTITY(1,1),
[IdRoulette] INT NOT NULL REFERENCES Roulettes(Id),
[Credit] VARCHAR(30),
[Bet] VARCHAR(30),
[RouletteNumber] INT,
[RouletteColor] VARCHAR(30),
CONSTRAINT PK_User PRIMARY KEY (Id),

CONSTRAINT FK_UsersRoulettes FOREIGN KEY ([IdRoulette]) REFERENCES [Roulettes]([Id])
);