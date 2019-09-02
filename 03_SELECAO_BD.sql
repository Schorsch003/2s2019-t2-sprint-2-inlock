--dql


--Listar todos os usu�rios
SELECT * FROM Usuarios;

--Listar todos os est�dios
SELECT * FROM Estudios;

--Listar todos os jogos
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos est�dios
SELECT Jogos.NomeJogo, Estudios.NomeEstudio 
	FROM Jogos 
	INNER JOIN Estudios 
	ON Jogos.EstudioId = Estudios.EstudioId;

--Buscar e trazer na lista todos os est�dios, mesmo que eles n�o contenham nenhum jogo de refer�ncia
SELECT Jogos.NomeJogo, Estudios.NomeEstudio 
	FROM Jogos 
	RIGHT JOIN Estudios 
	ON Jogos.EstudioId = Estudios.EstudioId;

--Buscar um usu�rio por email e senha
SELECT Usuarios.Email, Usuarios.Senha
    FROM Usuarios
    WHERE Usuarios.Email LIKE 'admin%'
    OR Usuarios.Senha LIKE '%min';

--Buscar um jogo por JogoId
SELECT * FROM Jogos WHERE JogoId = 2;

--Buscar um est�dio por EstudioId
SELECT * FROM Estudios WHERE EstudioId = 3;