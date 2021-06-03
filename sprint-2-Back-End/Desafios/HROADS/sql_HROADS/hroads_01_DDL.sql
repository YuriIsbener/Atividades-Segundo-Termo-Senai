

--1. Criar o banco de dados chamado SENAI_HROADS_MANHA/SENAI_HROADS_TARDE (conforme o período);
CREATE DATABASE SENAI_HROADS_MANHA
USE SENAI_HROADS_MANHA
----------------------------------------------------------------------------------------------------
--2. Criar as tabelas no banco de dados;

CREATE TABLE TipoHabilidade (
	idTipoHabilidade	INT PRIMARY KEY IDENTITY
	,NomeTipo			VARCHAR(200) NOT NULL
);

CREATE TABLE Habilidade(
	idHabilidade		INT PRIMARY KEY IDENTITY
	,idTipoHabilidade	INT FOREIGN KEY REFERENCES TipoHabilidade (idTipoHabilidade)
	,NomeHabilidade		VARCHAR(200) NOT NULL
);

CREATE TABLE Classe (
	idClasse			INT PRIMARY KEY IDENTITY
	,NomeClasse			VARCHAR(200) NOT NULL 
);

CREATE TABLE ClasseHabilidade (
	idHabilidade		INT FOREIGN KEY REFERENCES Habilidade (idHabilidade)
	,idClasse			INT FOREIGN KEY REFERENCES Classe (idClasse)
);

CREATE TABLE Personagens (
	idPersonagem		INT PRIMARY KEY IDENTITY
	,NomePersonagem		VARCHAR(200) NOT NULL
	,idClasse			INT FOREIGN KEY REFERENCES Classe (idClasse)
	,CapacidadeVida		INT
	,CapacidadeMana		INT
	,DataCriacao		DATETIME
	,DataAtualizacao	DATETIME
);

CREATE TABLE TipoDeUsuario (
	idTipoDeUsuario		INT PRIMARY KEY IDENTITY
	,NomeTipoUsuario	VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Usuario (
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoDeUsuario	INT FOREIGN KEY REFERENCES TipoDeUsuario (idTipoDeUsuario)
	,email				VARCHAR(200) NOT NULL
	,senha				VARCHAR(200) NOT NULL
);
----------------------------------------------------------------------------------------------------

