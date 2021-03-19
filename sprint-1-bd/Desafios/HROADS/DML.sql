USE SENAI_HROADS_MANHA

INSERT INTO TipoHabilidade (NomeTipo)
VALUES	('Ataque'),
		('Defesa'),
		('Cura'),
		('Magia');

INSERT INTO ClasseHabilidade (IdClasse, IdHabilidade)
VALUES	(1, 1),
		(1, 2),
		(2, 2),
		(3, 1),
        (4, 2),
        (4, 3),
        (6, 3);

INSERT INTO Habilidade (IdTipoHabilidade, NomeHabilidade)
VALUES	(1, 'Lança Mortal'),
		(2, 'Escudo Supremo'),
		(3, 'Recuperar Vida');

INSERT INTO Classe (NomeClasse)
VALUES	('Bárbaro'),
		('Cruzado'),
		('Caçadora de Demônios'),
		('Monge'),
		('Necromante'),
		('Feiticeiro'),
		('Arcanista');

INSERT INTO Personagem (NomePersonagem, IdClasse, CapacidadeHP, CapacidadeMP, DataCriacao, DataAtualizacao)
VALUES	('DeuBug', 1, 100, 80, (convert(datetime,'20-03-4 08:51:09 AM',5)), (convert(datetime,'20-03-04 08:51:09 AM',5))),
		('BitBug', 4, 70, 100, (convert(datetime,'20-03-4 08:51:09 AM',5)), (convert(datetime,'20-03-04 08:51:09 AM',5))),
		('Fer8', 7, 75, 60, (convert(datetime,'20-03-4 08:51:09 AM',5)), (convert(datetime,'20-03-04 08:51:09 AM',5)));

UPDATE Personagem
SET NomePersonagem = 'Fer7'
WHERE IdPersonagem = 3;

UPDATE Classe
SET NomeClasse = 'Necromancer'
WHERE IdClasse = 5;
SELECT * FROM Classe
