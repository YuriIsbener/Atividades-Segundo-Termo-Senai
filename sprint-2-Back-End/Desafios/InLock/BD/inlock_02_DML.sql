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
VALUES	(1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','15-05-2012',99.00),
		(3,'Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','26-10-2018',120.00);