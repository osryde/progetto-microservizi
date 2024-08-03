-- Droppa il database Pokedex se esiste
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Pokedex')
BEGIN
    DROP DATABASE Pokedex;
END
GO

-- Crea il database Pokedex
CREATE DATABASE Pokedex;
GO

USE Pokedex;
GO

CREATE TABLE Pokemons (
    PokemonId INT PRIMARY KEY,
    PokemonName VARCHAR(MAX),
    PokemonImage VARCHAR(MAX)
);
GO

-- Droppa il database Capture se esiste
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PokemonCapturable')
BEGIN
    DROP DATABASE PokemonCapturable;
END
GO

-- Crea il database Capture
CREATE DATABASE PokemonCapturable;
GO

USE PokemonCapturable;
GO

CREATE TABLE Pokemons (
    PokemonId INT PRIMARY KEY,
    PokemonName VARCHAR(MAX) NOT NULL,
    PokemonImage VARCHAR(MAX) NOT NULL
);

CREATE TABLE Item (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(MAX) NOT NULL
);

CREATE TABLE TransactionalOutbox (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Tabella NVARCHAR(MAX) ,
    Messaggio NVARCHAR(MAX)
);
GO

-- Droppa il database Trainer se esiste
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PokemonTrainer')
BEGIN
    DROP DATABASE PokemonTrainer;
END
GO

-- Crea il database Trainer
CREATE DATABASE PokemonTrainer;
GO

USE PokemonTrainer;
GO

CREATE TABLE Items (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL
);
GO