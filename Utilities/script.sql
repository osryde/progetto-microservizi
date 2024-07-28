-- Pokedex (Aggiungere quantity?)
CREATE TABLE Pokemon (
    PokemonId INT PRIMARY KEY,
    PokemonName VARCHAR(255) NOT NULL,
    PokemonImage VARCHAR(MAX) NOT NULL
);

-- Capture
CREATE TABLE Pokemon (
    PokemonId INT PRIMARY KEY,
    PokemonName VARCHAR(255) NOT NULL,
    PokemonImage VARCHAR(MAX) NOT NULL
);

CREATE TABLE Items (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(255) NOT NULL,
);

CREATE TABLE TransactionalOutbox (
    Id INT PRIMARY KEY,
    Tabella VARCHAR(255) NOT NULL,
    Messaggio VARCHAR(MAX) NOT NULL,
);


-- Trainer
CREATE TABLE Items (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL
);