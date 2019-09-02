--dml


--Inserir um usu�rio do tipo ADMINISTRADOR que tenha o email igual a �admin@admin.com� e senha igual a �admin�.
INSERT INTO Usuarios (Email, Senha, Permissao)
VALUES ('admin@admin.com','admin','ADMINISTRADOR')

--Inserir um usu�rio do tipo CLIENTE que tenha o email igual a �cliente@cliente.com� e senha igual a �cliente�.
INSERT INTO Usuarios (Email, Senha)
VALUES ('cliente@cliente.com','CLIENTE')


--Inserir tr�s est�dios: um com o nome de Blizzard, outro com o nome de Rockstar Studios e o �ltimo com o nome de Square Enix; Todos estes foram o usu�rio admin@admin.com que realizou o cadastro.
INSERT INTO Estudios(NomeEstudio, UsuarioId,PaisOrigem)
VALUES ('Blizzard', 1,'EUA')

INSERT INTO Estudios(NomeEstudio, UsuarioId,PaisOrigem)
VALUES ('Rockstar Studios', 1,'EUA')

INSERT INTO Estudios(NomeEstudio, UsuarioId,PaisOrigem)
VALUES ('Square Enix', 1,'Jap�o')


--Inserir um jogo com o nome de: Diablo 3, com data de lan�amento de: 15 de maio de 2012, que contenha a descri��o de: � um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�. E seu est�dio � a Blizzard. E o jogo custa R$ 99,00.
INSERT INTO Jogos(NomeJogo, DataLancamento, Descricao, EstudioId, Valor)
VALUES ('Diablo 3', '2012-05-15', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', 1, '99.00')

--Inserir um jogo com o nome de: Red Dead Redemption II com a descri��o de: jogo eletr�nico de a��o-aventura western. Seu est�dio ser� a Rockstar Studios. Lan�ado mundialmente em 26 de outubro de 2018. E o jogo custa R$ 120.
INSERT INTO Jogos(NomeJogo, DataLancamento, Descricao, EstudioId, Valor)
VALUES ('Red Dead Redemption II', '2018-10-26', 'jogo eletr�nico de a��o-aventura western', 2, '120.00')

--Jogo sem id associado para finalidade de ser listado no right join
INSERT INTO Jogos(NomeJogo, DataLancamento, Descricao, Valor)
VALUES ('Jogo NoEstudio', '2019-11-29', 'sem estudio id', '97.00')
