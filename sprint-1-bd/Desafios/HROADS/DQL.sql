SELECT * FROM Personagens

SELECT * FROM Classe

SELECT NomeClasse AS Classes FROM Classe

SELECT NomeHabilidade AS Habilidades FROM Habilidade

SELECT COUNT(NomeHabilidade) FROM Habilidade

SELECT IdHabilidade FROM Habilidade ORDER BY IdHabilidade

SELECT NomesTipo FROM TiposHabilidade

SELECT NomeHabilidade,NomeTipo FROM Habilidade
INNER JOIN TipoHabilidade 
ON Habilidade.IdTipoHabilidade=TipoHabilidade.IdTipoHabilidade

SELECT NomePersonagem,NomeClasse FROM Personagem
INNER JOIN Classe
ON Personagem.IdClasse=Classe.IdClasse

SELECT NomePersonagem, NomeClasse FROM Personagem
FULL OUTER JOIN Classe
ON Personagem.IdClasse=Classe.IdClasse

SELECT NomeClasse, NomeHabilidade FROM Classe
LEFT JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.IdClasse
LEFT JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade

SELECT NomeClasse, NomeHabilidade FROM Classe
INNER JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.IdClasse
INNER JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade

SELECT NomeClasse, NomeHabilidade FROM Classe
LEFT JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.IdClasse
LEFT JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade
