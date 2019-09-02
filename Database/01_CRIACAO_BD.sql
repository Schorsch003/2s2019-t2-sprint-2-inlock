--ddl


--Criar um banco de dados chamado M_InLock/T_InLock;
CREATE DATABASE T_InLock

USE T_InLock

--Criar uma tabela de usu�rios contendo os campos de UsuarioId, Email, Senha e Permiss�o do Usu�rio;
CREATE TABLE Usuarios(
UsuarioId INT PRIMARY KEY IDENTITY
,Email VARCHAR(255) NOT NULL UNIQUE
,Senha VARCHAR(255) NOT NULL
,Permissao VARCHAR(255) DEFAULT 'CLIENTE' 
);

--Criar uma tabela de est�dios com os campos de EstudioId, NomeEstudio e Pa�s de Origem (PaisOrigem), Data de Cria��o (DataCriacao); al�m disso, ao cadastrar o est�dio, dever� ser inclu�do na tabela um campo para mostrar qual foi o usu�rio que realizou o cadastro do est�dio chamado UsuarioId;
CREATE TABLE Estudios(
EstudioId INT PRIMARY KEY IDENTITY
,NomeEstudio VARCHAR(255) UNIQUE
,PaisOrigem VARCHAR(255)
,DataCriacao SMALLDATETIME
,UsuarioId  INT FOREIGN KEY REFERENCES Usuarios(UsuarioId) NOT NULL
);

--Criar uma tabela de jogos com os campos JogoId, NomeJogo, Descricao, DataLancamento, Valor e EstudioId;
CREATE TABLE Jogos(
JogoId INT PRIMARY KEY IDENTITY
,NomeJogo VARCHAR(255) UNIQUE
,Descricao VARCHAR(999)
,DataLancamento DATE
,Valor SMALLMONEY
,EstudioId INT FOREIGN KEY REFERENCES Estudios(EstudioId)
);

ALTER TABLE Jogos ALTER COLUMN EstudioID INT NULL
