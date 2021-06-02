USE inlock_games_manha_teste;

GO

INSERT INTO estudio (nomeEstudio)
VALUES	('Blizzard'),
		('Square Enix'),
		('Rockstar Studios');

GO

INSERT INTO tipoUser (tituloUser)
VALUES	('Administrador'),
		('Cliente');

GO

INSERT INTO usuario (emailUser, senhaUser,idTipoUser)
VALUES	('admin@admin.com','admin',1),
		('cliente@cliente.com','cliente',2);

GO

INSERT INTO jogo (idEstudio,nomeJogo,descricaoJogo,dataLancamento,valorJogo)
VALUES	(1,'Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','15-05-2012',99.00),
		(3,'Red Dead Redemption II','jogo eletrônico de ação-aventura western','26-10-2018',120.00);