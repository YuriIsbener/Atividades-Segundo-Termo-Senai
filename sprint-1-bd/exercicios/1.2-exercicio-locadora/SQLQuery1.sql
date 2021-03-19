USE Locadora
GO

CREATE TABLE Marca
(
	idMarca			INT PRIMARY KEY IDENTITY 
	,Nome			VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Modelos
(
	idModelo		INT PRIMARY KEY IDENTITY
	,idMarca		INT FOREIGN KEY REFERENCES Marca(idMarca)
	,Descricao		VARCHAR(200) NOT NULL 
);

CREATE TABLE Empresas
(
	idEmpresa		INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Veiculo
(
	idVeiculo		INT PRIMARY KEY IDENTITY
	,idEmpresa		INT FOREIGN KEY REFERENCES Empresas(idEmpresa)
	,idModelo		INT FOREIGN KEY REFERENCES Modelos(idModelo)
	,Placa			INT
);

CREATE TABLE Clientes
(
	idCliente		INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(200)NOT NULL
	,CPF			INT 
);

CREATE TABLE Alugueis
(
	idAluguel		INT PRIMARY KEY IDENTITY
	,idVeiculo		INT FOREIGN KEY REFERENCES Veiculo(idVeiculo)
	,idCliente		INT FOREIGN KEY REFERENCES Clientes(idCliente)
	,DataInicio		DATE
	,DataFim		DATE
);

