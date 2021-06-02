CREATE DATABASE inlock_games_manha_teste;

GO

USE inlock_games_manha_teste;

GO

CREATE TABLE estudio
(
	idEstudio INT PRIMARY KEY IDENTITY
	,nomeEstudio VARCHAR(100) UNIQUE NOT NULL
);

GO

CREATE TABLE jogo
(
	idJogo INT PRIMARY KEY IDENTITY
	,idEstudio INT FOREIGN KEY REFERENCES estudio (idEstudio)
	,nomeJogo VARCHAR(100) UNIQUE NOT NULL
	,descricaoJogo VARCHAR(250) NOT NULL
	,dataLancamento DATE NOT NULL
	,valorJogo FLOAT NOT NULL
);

GO

CREATE TABLE tipoUser
(
	idTipoUser INT PRIMARY KEY IDENTITY
	,tituloUser VARCHAR(200) UNIQUE NOT NULL
);

GO

CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,emailUser VARCHAR(200) UNIQUE NOT NULL
	,senhaUser VARCHAR(20) NOT NULL
	,idTipoUser INT FOREIGN KEY REFERENCES tipoUser (idTipoUser)
);

