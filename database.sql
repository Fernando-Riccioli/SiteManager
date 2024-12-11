CREATE DATABASE SiteManager;
USE SiteManager;

CREATE TABLE cantieri (
    nome VARCHAR(100) PRIMARY KEY,
    inizio DATE DEFAULT (CURRENT_DATE)
);

CREATE TABLE operai (
    nome VARCHAR(30) PRIMARY KEY,
    cantiere VARCHAR(100),
    FOREIGN KEY (cantiere) REFERENCES SiteManager.cantieri(nome)
);

CREATE TABLE tasks (
    descrizione VARCHAR(255) NOT NULL,
    cantiere VARCHAR(100),
    FOREIGN KEY (cantiere) REFERENCES SiteManager.cantieri(nome)
);

CREATE TABLE materiali (
    nome VARCHAR(100) NOT NULL,
    quantità FLOAT,
    unità VARCHAR(10) DEFAULT 'kg',
    cantiere VARCHAR(100),
    FOREIGN KEY (cantiere) REFERENCES SiteManager.cantieri(nome)
);