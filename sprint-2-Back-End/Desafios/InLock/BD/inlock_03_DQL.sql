USE inlock_games_manha_teste;

GO

SELECT * FROM usuario;

GO

SELECT * FROM estudio;

GO

SELECT * FROM jogo;

GO

SELECT idJogo, nomeJogo, descricaoJogo, dataLancamento, valorJogo, nomeEstudio FROM jogo
INNER JOIN estudio
ON jogo.idEstudio = estudio.idEstudio;

GO

SELECT nomeEstudio, nomeJogo FROM estudio
LEFT JOIN jogo
ON estudio.idEstudio = jogo.idEstudio;

GO

SELECT emailUser, senhaUser FROM usuario
WHERE emailUser ='admin@admin.com' AND senhaUser ='admin';

GO

SELECT * FROM jogo
WHERE idJogo = 1;

GO

SELECT * FROM estudio
WHERE idEstudio = 1;

