-- RealGabinete - Sistema de Gestão de Biblioteca
-- Script de criação da base de dados

CREATE DATABASE RealGabinete
GO

USE RealGabinete
GO


-- Salas e Prateleiras (localização física dos exemplares)
CREATE TABLE Salas
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome_Sala NVARCHAR(50) NOT NULL
);

CREATE TABLE Prateleiras
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Codigo NVARCHAR(20) NOT NULL,
    Sala_Id INT NOT NULL,

    CONSTRAINT FK_Prateleiras_Salas FOREIGN KEY (Sala_Id) REFERENCES Salas(Id)
);
 
-- Autores / Editoras / Categorias
CREATE TABLE Autores
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome NVARCHAR(50) NOT NULL,
    UltimoNome NVARCHAR(50) NOT NULL
);

CREATE TABLE Editoras
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome_Editora NVARCHAR(50) NOT NULL
);

CREATE TABLE Categorias
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome_Categoria NVARCHAR(50) NOT NULL
);
 
-- Livros (titulo) - nao representa exemplar fisico
CREATE TABLE Livros
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    ISBN VARCHAR(20) NOT NULL UNIQUE,
    Titulo NVARCHAR(100) NOT NULL,
    Data_Lancamento DATETIME NOT NULL,
    Valor DECIMAL(10,2),
    Autor_Id INT NOT NULL,
    Editora_Id INT,
    Categoria_Id INT,

    CONSTRAINT FK_Livros_Autores FOREIGN KEY (Autor_Id) REFERENCES Autores(Id),
    CONSTRAINT FK_Livros_Editoras FOREIGN KEY (Editora_Id) REFERENCES Editoras(Id),
    CONSTRAINT FK_Livros_Categorias FOREIGN KEY (Categoria_Id) REFERENCES Categorias(Id),
    CONSTRAINT CK_Livros_Valor CHECK (Valor >= 0)
);
 
-- Exemplares - copias fisicas de um Livro
 CREATE TABLE Exemplares
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Livro_Id INT NOT NULL,
    Codigo_Exemplar NVARCHAR(20) NOT NULL UNIQUE,
    Prateleira_Id INT,
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Disponivel',

    CONSTRAINT FK_Exemplares_Livros FOREIGN KEY (Livro_Id) REFERENCES Livros(Id),
    CONSTRAINT FK_Exemplares_Prateleiras FOREIGN KEY (Prateleira_Id) REFERENCES Prateleiras(Id),
    CONSTRAINT CK_Exemplares_Estado CHECK (Estado IN ('Disponivel','Emprestado','Reservado','Danificado','Perdido'))
);
 
-- Leitores
CREATE TABLE Leitores
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome NVARCHAR(50) NOT NULL,
    Ultimo_Nome NVARCHAR(50) NOT NULL,
    Email NVARCHAR(256) UNIQUE NOT NULL,
    Data_Registo DATETIME NOT NULL DEFAULT GETDATE()
);
 
-- Bibliotecarios - com autenticacao (sem distincao de roles)
CREATE TABLE Bibliotecarios
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nome NVARCHAR(50) NOT NULL,
    Ultimo_Nome NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARBINARY(256) NOT NULL,
    PasswordSalt VARBINARY(256) NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1
);
 
-- Emprestimos
CREATE TABLE Emprestimos
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Exemplar_Id INT NOT NULL,
    Leitor_Id INT NOT NULL,
    Bibliotecario_Id INT NOT NULL,
    Data_Emprestimo DATETIME NOT NULL DEFAULT GETDATE(),
    Data_Devolucao_Prevista DATETIME NOT NULL,
    Data_Devolucao_Real DATETIME NULL,

    CONSTRAINT FK_Emprestimos_Exemplares FOREIGN KEY (Exemplar_Id) REFERENCES Exemplares(Id),
    CONSTRAINT FK_Emprestimos_Leitores FOREIGN KEY (Leitor_Id) REFERENCES Leitores(Id),
    CONSTRAINT FK_Emprestimos_Bibliotecarios FOREIGN KEY (Bibliotecario_Id) REFERENCES Bibliotecarios(Id),
    CONSTRAINT CK_Emprestimos_Datas CHECK (Data_Devolucao_Prevista >= Data_Emprestimo)
);
GO

-- Garante que um exemplar nao pode ter dois emprestimos ativos em simultaneo
CREATE UNIQUE INDEX UX_Emprestimos_ExemplarAtivo
ON Emprestimos(Exemplar_Id)
WHERE Data_Devolucao_Real IS NULL;
GO
 
-- Reservas - reserva o titulo (Livro), nao um exemplar especifico
CREATE TABLE Reservas
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Livro_Id INT NOT NULL,
    Leitor_Id INT NOT NULL,
    Data_Reserva DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pendente',

    CONSTRAINT FK_Reservas_Livros FOREIGN KEY (Livro_Id) REFERENCES Livros(Id),
    CONSTRAINT FK_Reservas_Leitores FOREIGN KEY (Leitor_Id) REFERENCES Leitores(Id),
    CONSTRAINT CK_Reservas_Status CHECK (Status IN ('Pendente','Concluida','Cancelada'))
);
 
-- Multas - associadas a um Emprestimo (ex: devolucao atrasada)
-- O valor e calculado na camada de negocio (C#/EF Core), nao aqui.
CREATE TABLE Multas
(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Emprestimo_Id INT NOT NULL,
    Valor DECIMAL(10,2) NOT NULL,
    Data_Emissao DATETIME NOT NULL DEFAULT GETDATE(),
    Paga BIT NOT NULL DEFAULT 0,
    Data_Pagamento DATETIME NULL,

    CONSTRAINT FK_Multas_Emprestimos FOREIGN KEY (Emprestimo_Id) REFERENCES Emprestimos(Id),
    CONSTRAINT CK_Multas_Valor CHECK (Valor >= 0)
);
GO
 
-- "Historico de Emprestimos" como VIEW (sem duplicar dados)
CREATE VIEW Historico_Emprestimos AS
SELECT
    e.Id,
    ex.Codigo_Exemplar,
    l.Titulo,
    lt.Nome AS Nome_Leitor,
    b.Nome AS Nome_Bibliotecario,
    e.Data_Emprestimo,
    e.Data_Devolucao_Prevista,
    e.Data_Devolucao_Real
FROM Emprestimos e
JOIN Exemplares ex ON ex.Id = e.Exemplar_Id
JOIN Livros l ON l.Id = ex.Livro_Id
JOIN Leitores lt ON lt.Id = e.Leitor_Id
JOIN Bibliotecarios b ON b.Id = e.Bibliotecario_Id
WHERE e.Data_Devolucao_Real IS NOT NULL;
GO