USE Locadora

INSERT INTO Marca (Nome)
VALUES						('Ford')
						   ,('GM')
						   ,('Fiat');
GO

INSERT INTO Modelos (idMarca, Descricao)
VALUES						(1, 'Fiesta')
						   ,(2,' Onix')
						   ,(3, 'Argo');
GO

INSERT INTO Empresas (Nome)
VALUES						('Unidas')
						   ,('Localiza');
GO

INSERT INTO Veiculo (idEmpresa, idModelo, Placa)
VALUES						(1, 1, 1805)
							,(1, 2, 1010)
							,(2, 3, 1978)
							,(2, 1, 9876)
GO

INSERT INTO Clientes (Nome, CPF)
VALUES						('Saulo', 99999999999)
							,('Caique', 88888888888)
GO

INSERT INTO Alugueis (idVeiculo, idCliente, DataInicio, DataFim)
VALUES						(1, 1, '19/01/2019', '20/01/2019')
							,(1, 2, '20/01/2019', '21/01/2019')
							,(2, 3, '21/01/2019', '21/01/2019')
							,(2, 2, '22/01/2019', '22/01/2019')
GO


