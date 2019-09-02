--dql


--Listar todos os usuários
SELECT * FROM Usuarios;

--Listar todos os estúdios
SELECT * FROM Estudios;

--Listar todos os jogos
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos estúdios
SELECT Jogos.NomeJogo, Estudios.NomeEstudio 
	FROM Jogos 
	INNER JOIN Estudios 
	ON Jogos.EstudioId = Estudios.EstudioId;

--Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência
SELECT Jogos.NomeJogo, Estudios.NomeEstudio 
	FROM Jogos 
	RIGHT JOIN Estudios 
	ON Jogos.EstudioId = Estudios.EstudioId;

--Buscar um usuário por email e senha
SELECT Usuarios.Email, Usuarios.Senha
    FROM Usuarios
    WHERE Usuarios.Email LIKE 'admin%'
    OR Usuarios.Senha LIKE '%min';

--Buscar um jogo por JogoId
SELECT * FROM Jogos WHERE JogoId = 2;

--Buscar um estúdio por EstudioId
SELECT * FROM Estudios WHERE EstudioId = 3;