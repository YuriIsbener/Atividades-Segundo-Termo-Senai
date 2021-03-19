USE pclinics
GO 

INSERT INTO Clinicas (RazaoSocial, CNPJ, Endereco)
VALUES						('Meu Pimpão', 9999999, 'Av. Barão de Limeira, 539')
GO

INSERT INTO Veterianarios (idClinica, CNPJ, Nome)
VALUES						(4, 432551, 'Saulo')
						   ,(4, 653655, 'Caique')
GO

INSERT INTO TiposPets (Descricao)
VALUES						('Cachorro')
						   ,('Gato')
GO

INSERT INTO Racas (idTiposPets, Descricao)
VALUES						(1, 'Poodle')
						   ,(1, 'Labrador')
						   ,(1, 'SRD')
						   ,(2, 'Siamês')
GO

INSERT INTO Donos (Nome)
VALUES						('Paulo')
						   ,('Odirlei')
GO

INSERT INTO Pets (idRacas, idDono, Nome, DataNascimento)
VALUES						(1, 1, 'Junior', '10/10/2018')
						   ,(4, 1, 'Loli', '18/05/2017')
						   ,(1, 2, 'Sammy', '16/06/2016')
GO

INSERT INTO Atendimentos (idVeterinario, idPet, Descriacao, DataAtendimento)
VALUES						(1, 1, 'Restam 10 dias de vida', '22/01/2019')
						   ,(2, 2, 'O paciente está ok', '21/01/2019')
						   ,(2, 1, 'O paciente está ok', '22/01/2019')
GO