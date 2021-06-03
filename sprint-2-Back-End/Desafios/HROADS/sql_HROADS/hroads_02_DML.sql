USE SENAI_HROADS_MANHA


--3. Inserir os registros conforme descrição no próprio texto (classes, habilidades, tipos de habilidades e personagens);
INSERT INTO TipoHabilidade (NomeTipo)
VALUES						('Ataque')
						   ,('Defesa')
						   ,('Cura')
						   ,('Magia');

INSERT INTO Habilidade (NomeHabilidade, idTipoHabilidade)
VALUES					('Lança Mortal', 1)
						,('Escudo Supremo', 2)
						,('Recuperar Vida', 3);

INSERT INTO Classe		(NomeClasse)
VALUES					('Bárbaro')
						,('Cruzado')
						,('Caçadora de Demônios')
						,('Monge')
						,('Necromante')
						,('Feiticeiro')
						,('Arcanista');

INSERT INTO ClasseHabilidade (idClasse, idHabilidade)
VALUES					(1, 1)
						,(1, 2)
						,(2, 2)
						,(3, 1)
						,(4, 2)
						,(4, 3)
						,(6, 3);


INSERT INTO Personagens (idClasse, NomePersonagem, CapacidadeVida, CapacidadeMana, DataAtualizacao, DataCriacao)
VALUES					(1, 'DeuBug', 100, 80, (convert(datetime,'03-03-21 08:51:00 AM',5)),(convert(datetime,'18-01-19 10:34:09 PM',5)))
						,(4, 'BitBug', 70, 100, (convert(datetime,'03-03-21 08:51:00 AM',5)),(convert(datetime,'17-03-16 10:34:09 PM',5)))
						,(7, 'Fer8', 75, 60, (convert(datetime,'03-03-21 08:51:00 AM',5)),(convert(datetime,'18-03-18 10:34:09 PM',5)));
						

INSERT INTO TipoDeUsuario (NomeTipoUsuario)
VALUES					  ('Jogador')
						  ,('Administrador');

INSERT INTO Usuario (idTipoDeUsuario, email, senha)
VALUES				(2, 'admin@gmail.com', 'admin123')
					,(1, 'jogador@gmail.com', 'jogador123');
--------------------------------------------------------------------------------------------------------------------------------------------------
--4. Atualizar o nome do personagem Fer8 para Fer7;
UPDATE Personagens
SET NomePersonagem = 'Fer7', DataAtualizacao = (convert(datetime,'03-03-21 09:13:25 AM',5))
WHERE idPersonagem = 5;

--------------------------------------------------------------------------------------------------------------------------------------------------
--5. Atualizar o nome da classe de Necromante para Necromancer;
UPDATE Classe
SET NomeClasse = 'Necromancer'
WHERE idClasse = 5;