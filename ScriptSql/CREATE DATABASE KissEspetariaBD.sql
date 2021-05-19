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
    Salario MONEY NOT NULL,

        PRIMARY KEY (AtendenteId),
    FOREIGN KEY (AtendenteId) REFERENCES Pessoas(PessoaId)
)
GO

CREATE TABLE PessoasGarcon
(
    GarconId INT NOT NULL,
    ValorDia MONEY NOT NULL,
    Comissao MONEY NOT NULL,

    PRIMARY KEY (GarconId),
    FOREIGN KEY (GarconId) REFERENCES Pessoas(PessoaId)
)
GO

CREATE TABLE Comandas
(
    ComandaId INT NOT NULL IDENTITY,
    ValorTotal MONEY NOT NULL,
    AtendenteId INT NOT NULL,
    GarconId INT NOT NULL,
    Status INT NOT NULL,

    PRIMARY KEY (ComandaId),
    FOREIGN KEY (AtendenteId) REFERENCES PessoasAtendente(AtendenteId),
    FOREIGN KEY (GarconId) REFERENCES PessoasGarcon(GarconId),
)
GO

CREATE TABLE Produtos
(
    ProdutoId INT NOT NULL IDENTITY,
    Descricao VARCHAR(50) NOT NULL,
    Status INT NOT NULL,
    QtdEstque INT NOT NULL,
    ValorTotal MONEY NOT NULL,

    PRIMARY KEY (ProdutoId),
)
GO

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

