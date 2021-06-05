CREATE DATABASE KissEspetariaBD
GO

USE KissEspetariaBD
GO


CREATE TABLE Pessoas
(
    PessoaId INT NOT NULL IDENTITY,
    Nome VARCHAR(50) NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    Telefone VARCHAR(13) NOT NULL,

    PRIMARY KEY (PessoaId)
)
GO

CREATE TABLE PessoasAtendente
(
    AtendenteId INT NOT NULL,
    Login VARCHAR(10) NOT NULL,
    Senha VARCHAR(16) NOT NULL,
    Salario DECIMAL(6,2) NOT NULL,
    [Admin] BIT NOT NULL,

    PRIMARY KEY (AtendenteId),
    FOREIGN KEY (AtendenteId) REFERENCES Pessoas(PessoaId)
)
GO


CREATE TABLE PessoasGarcon
(
    GarconId INT NOT NULL,
    ValorDia DECIMAL(6,2) NOT NULL,
    Comissao DECIMAL(6,2) NOT NULL,
    Ativo BIT,

    PRIMARY KEY (GarconId),
    FOREIGN KEY (GarconId) REFERENCES Pessoas(PessoaId)
)
GO

CREATE TABLE Comandas
(
    ComandaId INT NOT NULL IDENTITY,
    ValorTotal DECIMAL(6,2) NOT NULL,
    AtendenteId INT NOT NULL,
    GarconId INT NOT NULL,
    Status INT NOT NULL,
    Observacao VARCHAR(MAX),

    PRIMARY KEY (ComandaId),
    FOREIGN KEY (AtendenteId) REFERENCES PessoasAtendente(AtendenteId),
    FOREIGN KEY (GarconId) REFERENCES PessoasGarcon(GarconId),
)
GO

CREATE TABLE Produtos
(
    ProdutoId INT NOT NULL IDENTITY,
    Descricao VARCHAR(50) NOT NULL,
    QtdEstque INT NOT NULL,
    Valor DECIMAL(6,2) NOT NULL,

    PRIMARY KEY (ProdutoId),
)
GO

SELECT *
FROM Produtos


CREATE TABLE ProdutoComandaItem
(
    ProdutoId INT NOT NULL,
    ComandaId INT NOT NULL,
    Quantidade INT NOT NULL,
    ValorUnitario MONEY NOT NULL,

    PRIMARY KEY (ProdutoId, ComandaId),
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(ProdutoId),
    FOREIGN KEY (ComandaId) REFERENCES Comandas(ComandaId),
)
GO


--PROCEDURE ATENDENTE
----------------------------------------------------
--   CREATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_atendente_create
    @Nome VARCHAR(50),
    @CPF VARCHAR(11),
    @Telefone VARCHAR(13),
    @Login VARCHAR(10),
    @Senha VARCHAR(16),
    @Salario DECIMAL(6,2),
    @Admin BIT
AS
INSERT INTO Pessoas
VALUES
    (@Nome, @CPF, @Telefone)

INSERT INTO PessoasAtendente
VALUES
    (@@IDENTITY, @Login, @Senha, @Salario, @Admin)
GO

exec sp_atendente_create 'Luis', '46093823857', '190', 'lhenrique', '1234', 1200, TRUE
GO

exec sp_atendente_create 'Lucas', '545770221', '32131162', 'lucasadm', '4321', 5000, FALSE
GO


----------------------------------------------------
--   UPDATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_atendente_update
    @PessoaId INT,
    @Nome VARCHAR(50),
    @CPF VARCHAR(11),
    @Telefone VARCHAR(13),
    @Login VARCHAR(10),
    @Senha VARCHAR(16),
    @Salario DECIMAL(6,2),
    @Admin BIT
AS
UPDATE Pessoas SET
    Nome = @Nome,
    CPF = @CPF,
    Telefone = @Telefone
    WHERE PessoaId = @PessoaId

DECLARE @AtendenteId AS INT = @PessoaId

UPDATE PessoasAtendente SET
    [Login] = @Login,
    Senha = @Senha,
    Salario = @Salario,
    [Admin] = @Admin
    WHERE AtendenteId = @AtendenteId 
GO

exec sp_atendente_update 1, 'Luis Henrique', '460938', '190-190', 'ladmin', '123456', 3000, FALSE
GO


----------------------------------------------------
--   DELETE                 ------------------------
----------------------------------------------------
CREATE PROC sp_atendente_delete
    @AtendenteId INT
AS
DELETE FROM PessoasAtendente
    WHERE AtendenteId = @AtendenteId

DECLARE @PessoaId AS INT = @AtendenteId

DELETE FROM Pessoas
    WHERE PessoaId = @PessoaId
GO

--exec sp_atendente_delete 1
--GO

----------------------------------------------------
--   BUSCAS P/ ID              ---------------------
----------------------------------------------------
CREATE PROC sp_atendente_id
    @PessoaId INT
AS
SELECT P.PessoaId AS Codigo,
    P.Nome AS Nome,
    P.CPF,
    P.Telefone,
    PA.[Login],
    PA.Salario AS Salario,
    CASE PA.Admin
            WHEN 1 THEN 'TRUE'
            ELSE 'FALSE'
        END Administrador
FROM Pessoas as P
    INNER JOIN PessoasAtendente as PA
    on P.PessoaId = PA.AtendenteId
WHERE P.PessoaId = @PessoaId 
GO

EXEC sp_atendente_id 2
GO

--VIEW ATENDENTE
----------------------------------------------------
--   VIEW                      ---------------------
----------------------------------------------------
CREATE VIEW vw_atendente
AS
    SELECT P.PessoaId AS Codigo,
        P.Nome AS Nome,
        P.CPF,
        P.Telefone,
        PA.[Login],
        PA.Salario AS Salario,
        CASE PA.Admin
            WHEN 1 THEN 'TRUE'
            ELSE 'FALSE'
        END Administrador

    FROM Pessoas as P
        INNER JOIN PessoasAtendente as PA
        on P.PessoaId = PA.AtendenteId
GO

SELECT *
FROM vw_atendente
GO


--PROCEDURE PRODUTO
----------------------------------------------------
--   CREATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_produto_create
    @Descricao VARCHAR(50),
    @QtdEstque INT,
    @Valor MONEY
AS
INSERT INTO Produtos
VALUES
    (@Descricao, @QtdEstque, @Valor)
GO

EXEC sp_produto_create 'Chocolate em Pó', 5, 5.50
GO

----------------------------------------------------
--   UPDATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_produto_update
    @ProdutoId INT,
    @Descricao VARCHAR(50),
    @QtdEstoque INT,
    @Valor MONEY
AS
UPDATE Produtos SET
    Descricao = @Descricao,
    QtdEstque = @QtdEstoque,
    Valor = @Valor
    WHERE ProdutoId = @ProdutoId
GO

EXEC sp_produto_update 1, 'Chocolate em Pó', 4, 4.59
GO

----------------------------------------------------
--   DELETE                 ------------------------
----------------------------------------------------
CREATE PROC sp_produto_delete
    @ProdutoId INT
AS
DELETE FROM Produtos
WHERE ProdutoId = @ProdutoId
GO

--PROC PESQUISAR PRODUTO P/ ID - NÃO TEVE NECESSIDADE
--VIEW PRODUTO - NÃO TEVE NECESSIDADE

