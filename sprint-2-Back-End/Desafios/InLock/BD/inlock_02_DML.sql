USE inlock_games_manha

INSERT INTO estudios (nomeEstudio)
VALUES				 ('Blizzard')
					 ,('Rockstar Studios')
					 ,('Square Enix');

INSERT INTO jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			  ('Diablo 3', 'jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�' , 
				   '15/05/2012', 99, 1)
				  ,('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western' , 
				   '26/10/2018', 120, 2);

INSERT INTO tiposDeUsuario (titulo)
VALUES					   ('Administrador')
						   ,('Cliente');

INSERT INTO usuarios (email, senha, idTipoUsuario)
VALUES				 ('admin@admin.com', 'admin', 1)
					 ,('cliente@cliente.com', 'cliente', 2)

