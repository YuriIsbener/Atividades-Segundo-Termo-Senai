USE pclinics

CREATE TABLE Clinicas
(
	idClinica				INT PRIMARY KEY IDENTITY
	,RazaoSocial			VARCHAR(200)
	,CNPJ					INT
	,Endereco				VARCHAR(200)
);

CREATE TABLE Veterianarios
(
	idClinica				INT FOREIGN KEY REFERENCES Clinicas(idClinica)
	,idVeterinario			INT PRIMARY KEY IDENTITY
	,Nome					VARCHAR(200)
	,CNPJ					INT	
);

CREATE TABLE TiposPets
(
	idTiposPets				INT PRIMARY KEY IDENTITY
	,Descricao				VARCHAR(200)
);

CREATE TABLE Racas
(
	idRacas					INT PRIMARY KEY IDENTITY
	,idTiposPets			INT FOREIGN KEY REFERENCES TiposPets(idTiposPets)
	,Descricao				VARCHAR(200)
);

CREATE TABLE Donos
(
	idDono					INT PRIMARY KEY IDENTITY
	,Nome					VARCHAR(200)
);

CREATE TABLE Pets
(
	idPet					INT PRIMARY KEY IDENTITY
	,idRacas				INT FOREIGN KEY REFERENCES Racas(idRacas)
	,idDono					INT FOREIGN KEY REFERENCES Donos(idDono)
	,Nome					VARCHAR(200)
	,DataNascimento			DATE
);

CREATE TABLE Atendimentos
(
	idAtendimento			INT PRIMARY KEY IDENTITY
	,idVeterinario			INT FOREIGN KEY REFERENCES Veterianarios(idVeterinario)
	,idPet					INT FOREIGN KEY REFERENCES Pets(idPet)
	,Descriacao				VARCHAR(200)
	,DataAtendimento		DATE
);