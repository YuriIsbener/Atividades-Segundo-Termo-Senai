USE SENAI_HROADS_MANHA

--6. Selecionar todos os personagens;
SELECT * FROM Personagens;

----------------------------------------------------------------------------------------------------
--7. Selecionar todos as classes;
SELECT * FROM Classe;

----------------------------------------------------------------------------------------------------
--8. Selecionar somente o nome das classes;
SELECT NomeClasse AS Classes
FROM Classe;

----------------------------------------------------------------------------------------------------
--9. Selecionar todas as habilidades;
SELECT * FROM Habilidade

----------------------------------------------------------------------------------------------------
--10. Realizar a contagem de quantas habilidades estão cadastradas;
SELECT COUNT(NomeHabilidade) AS 'Número De Habilidade' FROM Habilidade

----------------------------------------------------------------------------------------------------
--11. Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHabilidade, NomeHabilidade FROM Habilidade
ORDER BY idHabilidade 

----------------------------------------------------------------------------------------------------
--12. Selecionar todos os tipos de habilidades;
SELECT * FROM TipoHabilidade

----------------------------------------------------------------------------------------------------
--13. Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT NomeHabilidade AS Habilidades , NomeTipo AS 'Tipos de Habilidade'  FROM Habilidade
INNER JOIN TipoHabilidade
ON Habilidade.idTipoHabilidade = TipoHabilidade.idTipoHabilidade
----------------------------------------------------------------------------------------------------
--14. Selecionar todos os personagens e suas respectivas classes;
SELECT NomePersonagem AS Personagem, NomeClasse AS Classe FROM Personagens
INNER JOIN Classe 
ON Personagens.idClasse = Classe.idClasse


----------------------------------------------------------------------------------------------------
--15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
SELECT NomeClasse AS Classes, NomePersonagem AS Personagens FROM Classe
FULL OUTER JOIN Personagens
ON Personagens.idClasse = Classe.idClasse

----------------------------------------------------------------------------------------------------
--16. Selecionar todas as classes e suas respectivas habilidades;
SELECT NomeClasse AS Classes, NomeHabilidade AS Habilidades FROM Classe
LEFT JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.idClasse
LEFT JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade

----------------------------------------------------------------------------------------------------
--17. Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT NomeHabilidade AS Habilidades, NomeClasse AS Classes FROM Classe
INNER JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.idClasse
INNER JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade

----------------------------------------------------------------------------------------------------
--18. Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT NomeHabilidade AS Habilidades, NomeClasse AS Classes FROM Classe
RIGHT JOIN ClasseHabilidade
ON Classe.IdClasse = ClasseHabilidade.idClasse
RIGHT JOIN Habilidade
ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade

----------------------------------------------------------------------------------------------------

SELECT * FROM TipoDeUsuario
SELECT * FROM Usuario



