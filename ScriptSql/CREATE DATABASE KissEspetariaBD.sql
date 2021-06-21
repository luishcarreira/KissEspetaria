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
    Salario DECIMAL(6,2) NOT NULL,

    PRIMARY KEY (PessoaId)
)
GO

CREATE TABLE PessoasAtendente
(
    AtendenteId INT NOT NULL,
    Login VARCHAR(10) NOT NULL,
    Senha VARCHAR(16) NOT NULL,
    [Admin] BIT NOT NULL,

    PRIMARY KEY (AtendenteId),
    FOREIGN KEY (AtendenteId) REFERENCES Pessoas(PessoaId)
)
GO


CREATE TABLE PessoasGarcon
(
    GarconId INT NOT NULL,
    Comissao DECIMAL(3,2) NOT NULL,
    RegimeTrab VARCHAR(40),
    Ativo BIT,

    PRIMARY KEY (GarconId),
    FOREIGN KEY (GarconId) REFERENCES Pessoas(PessoaId)
)
GO


CREATE TABLE Comandas
(
    ComandaId INT NOT NULL IDENTITY,
    AtendenteId INT NOT NULL,
    GarconId INT NOT NULL,
    DataEmissao VARCHAR(12),
    ValorTotal DECIMAL(6,2) NOT NULL,
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


CREATE TABLE ProdutoComandaItem
(
    ProdutoId INT NOT NULL,
    ComandaId INT NOT NULL,
    Quantidade INT NOT NULL,
    ValorUnitario DECIMAL(6,2) NOT NULL,

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
    @Salario DECIMAL(6,2),
    @Login VARCHAR(10),
    @Senha VARCHAR(16),
    @Admin BIT
AS
INSERT INTO Pessoas
VALUES
    (@Nome, @CPF, @Telefone, @Salario)

INSERT INTO PessoasAtendente
VALUES
    (@@IDENTITY, @Login, @Senha, @Admin)
GO

exec sp_atendente_create 'Luis', '46093823857', '190', 1200, 'lhenrique', '1234', TRUE
GO

exec sp_atendente_create 'Lucas', '545770221', '32131162', 5000, 'lucasadm', '4321', FALSE
GO

----------------------------------------------------
--   UPDATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_atendente_update
    @PessoaId INT,
    @Nome VARCHAR(50),
    @CPF VARCHAR(11),
    @Telefone VARCHAR(13),
    @Salario DECIMAL(6,2),
    @Login VARCHAR(10),
    @Senha VARCHAR(16),
    @Admin BIT
AS
UPDATE Pessoas SET
    Nome = @Nome,
    CPF = @CPF,
    Telefone = @Telefone,
    Salario = @Salario
    WHERE PessoaId = @PessoaId

DECLARE @AtendenteId AS INT = @PessoaId

UPDATE PessoasAtendente SET
    [Login] = @Login,
    Senha = @Senha,
    [Admin] = @Admin
    WHERE AtendenteId = @AtendenteId 
GO

use KissEspetariaBD
EXEC sp_atendente_update 1, 'Luis H.', '46093823857', '190', 1200, 'lhenrique', '123456', TRUE
go
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
-- CREATE PROC sp_atendente_id
--     @PessoaId INT
-- AS
-- SELECT P.PessoaId,
--     P.Nome,
--     P.CPF,
--     P.Telefone,
--     PA.[Login],
--     PA.Salario,
--     CASE PA.Admin
--             WHEN 1 THEN 'TRUE'
--             ELSE 'FALSE'
--         END [Admin]
-- FROM Pessoas as P
--     INNER JOIN PessoasAtendente as PA
--     on P.PessoaId = PA.AtendenteId
-- WHERE P.PessoaId = @PessoaId 
-- GO

-- CRIADO SELECT PARA CONSEGUIR RETORNAR CAMPO SENHA

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
        P.Salario AS Salario,
        PA.[Login],
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
    @QtdEstoque INT,
    @Valor MONEY
AS
INSERT INTO Produtos
VALUES
    (@Descricao, @QtdEstoque, @Valor)
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


--PROCEDURE GARÇON
----------------------------------------------------
--   CREATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_garcon_create
    @Nome VARCHAR(50),
    @CPF VARCHAR(11),
    @Telefone VARCHAR(13),
    @Salario DECIMAL(6,2),
    @Comissao DECIMAL(3,2),
    @RegimeTrab VARCHAR(40),
    @Ativo BIT
AS
INSERT INTO Pessoas
VALUES
    (@Nome, @CPF, @Telefone, @Salario)

INSERT INTO PessoasGarcon
VALUES
    (@@IDENTITY, @Comissao, @RegimeTrab, @Ativo)
GO

EXEC sp_garcon_create "Matheus G.", "80808080", "174256399", 1000, 1.90, "CLT", TRUE
GO

----------------------------------------------------
--   UPDATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_garcon_update
    @PessoaId INT,
    @Nome VARCHAR(50),
    @CPF VARCHAR(11),
    @Telefone VARCHAR(13),
    @Salario DECIMAL(6,2),
    @Comissao DECIMAL(3,2),
    @RegimeTrab VARCHAR(40),
    @Ativo BIT
AS
UPDATE Pessoas SET
    Nome = @Nome,
    CPF = @CPF,
    Telefone = @Telefone,
    Salario = @Salario
    WHERE PessoaId = @PessoaId

DECLARE @GarconId AS INT = @PessoaId

UPDATE PessoasGarcon SET
    Comissao = @Comissao,
    RegimeTrab = @RegimeTrab,
    Ativo = @Ativo
    WHERE GarconId = @GarconId 
GO


----------------------------------------------------
--   DELETE                 ------------------------
----------------------------------------------------
CREATE PROC sp_garcon_delete
    @GarconId INT
AS
DELETE FROM PessoasGarcon
    WHERE GarconId = @GarconId

DECLARE @PessoaId AS INT = @GarconId

DELETE FROM Pessoas
    WHERE PessoaId = @PessoaId
GO

----------------------------------------------------
--   BUSCAS P/ ID              ---------------------
----------------------------------------------------
CREATE PROC sp_garcon_id
    @PessoaId INT
AS
SELECT P.PessoaId,
    P.Nome,
    P.CPF,
    P.Telefone,
    P.Salario,
    PG.Comissao,
    PG.RegimeTrab,
    CASE PG.Ativo
            WHEN 1 THEN 'TRUE'
            ELSE 'FALSE'
        END Ativo
FROM Pessoas as P
    INNER JOIN PessoasGarcon as PG
    on P.PessoaId = PG.GarconId
WHERE P.PessoaId = @PessoaId 
GO

--VIEW GARÇON
----------------------------------------------------
--   VIEW                      ---------------------
----------------------------------------------------
CREATE VIEW vw_garcon
AS
    SELECT P.PessoaId,
        P.Nome,
        P.CPF,
        P.Telefone,
        P.Salario,
        PG.Comissao,
        PG.RegimeTrab,
        CASE PG.Ativo
            WHEN 1 THEN 'TRUE'
            ELSE 'FALSE'
        END Ativo
    FROM Pessoas as P
        INNER JOIN PessoasGarcon as PG
        on P.PessoaId = PG.GarconId
GO

--PROCEDURE COMANDA
----------------------------------------------------
--   CREATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_comanda_create
    @AtendenteId INT,
    @GarconId INT,
    @DataEmissao DATE,
    @Status INT,
    @Observacao VARCHAR
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN 
        
        INSERT INTO Comandas
        (AtendenteId, GarconId, DataEmissao, [Status], Observacao)
    VALUES(@AtendenteId, @GarconId, @DataEmissao, @Status, @Observacao)

        SELECT @@IDENTITY;
    
        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        SELECT ERROR_MESSAGE() AS RETORNO;
    END CATCH
END
GO



----------------------------------------------------
--   UPDATE                 ------------------------
----------------------------------------------------
--VERIFICAR VIABILIDADE DE ALTERAÇÃO DE COMANDA


----------------------------------------------------
--   DELETE                 ------------------------
----------------------------------------------------
--NÃO PODEREMOS EXCLUIR UMA COMANDA

----------------------------------------------------
--   BUSCAR P/ ID           ------------------------
----------------------------------------------------
CREATE PROC sp_comanda_item_id
    @ComandaId INT
AS
SELECT
    c.ComandaId Comanda,
    COUNT(*) 'Nº Item',
    c.AtendenteId Atendente,
    c.GarconId Garçom,
    p.Descricao Produto,
    PCI.Quantidade Qtd,
    c.ValorTotal 'Valor Total'

FROM Comandas C, Produtos P, ProdutoComandaItem PCI
WHERE PCI.ComandaId = @ComandaId
GO


--VIEW COMANDA
----------------------------------------------------
--   VIEW                      ---------------------
----------------------------------------------------


--PROCEDURE ITEM
----------------------------------------------------
--   CREATE                 ------------------------
----------------------------------------------------
CREATE PROC sp_item_create
    @ProdutoId INT,
    @ComandaId INT,
    @Quantidade INT ,
    @ValorUnitario DECIMAL(6,2)
AS
INSERT INTO ProdutoComandaItem
VALUES(@ProdutoId, @ComandaId, @Quantidade, @ValorUnitario)
GO




--QUERYS P/ DASHBOARD(HOME)
----------------------------------------------------
--   GANHOS(DIA)               ---------------------
----------------------------------------------------
CREATE PROC sp_comandas_dia
    @Dia CHAR(2)
AS
SELECT SUM(ValorTotal) Ganho
FROM Comandas
WHERE DAY(DataEmissao) = @Dia 
GO


CREATE PROC sp_comandas_mes
    @Mes CHAR(1)
AS

SELECT SUM(ValorTotal) Ganho
FROM Comandas
WHERE MONTH(DataEmissao) = @Mes
GO



CREATE VIEW vw_comanda_status
AS
    SELECT
        c.ComandaId Comanda,
        c.AtendenteId Atendente,
        P.Nome 'Nome Atendente',
        c.GarconId Garçom,
        P2.Nome 'Nome Garcom',
        c.DataEmissao,
        c.ValorTotal Total,
        CASE [Status]
            WHEN 1 THEN 'Encerrado'
            ELSE 'Em Aberto'
        END Status
    FROM Comandas C
        INNER JOIN Pessoas P ON C.AtendenteId = P.PessoaId
        INNER JOIN Pessoas P2 ON c.GarconId = P2.PessoaId
GO