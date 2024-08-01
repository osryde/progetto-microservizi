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
    PokemonName VARCHAR(255) NOT NULL,
    PokemonImage VARCHAR(MAX) NOT NULL
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
    PokemonName VARCHAR(255) NOT NULL,
    PokemonImage VARCHAR(MAX) NOT NULL
);

CREATE TABLE Item (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(255) NOT NULL
);

CREATE TABLE TransactionalOutbox (
    Id INT,
    Tabella VARCHAR(255) ,
    Messaggio VARCHAR(MAX)
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