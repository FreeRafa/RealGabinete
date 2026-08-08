
CREATE DATABASE RealGabinete;
GO

USE RealGabinete;
GO

-- =========================================================
-- 1. ROOMS — não depende de nada
-- =========================================================
CREATE TABLE Rooms (
    Id      INT IDENTITY(1,1) PRIMARY KEY,
    Name    NVARCHAR(100) NOT NULL
);
GO

-- =========================================================
-- 2. AUTHORS — não depende de nada
-- =========================================================
CREATE TABLE Authors (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    FirstName   NVARCHAR(100) NOT NULL,
    LastName    NVARCHAR(100) NOT NULL
);
GO

-- =========================================================
-- 3. PUBLISHERS — não depende de nada
-- =========================================================
CREATE TABLE Publishers (
    Id      INT IDENTITY(1,1) PRIMARY KEY,
    Name    NVARCHAR(150) NOT NULL
);
GO

-- =========================================================
-- 4. CATEGORIES — não depende de nada
-- =========================================================
CREATE TABLE Categories (
    Id      INT IDENTITY(1,1) PRIMARY KEY,
    Name    NVARCHAR(100) NOT NULL
);
GO

-- =========================================================
-- 5. SHELVES — depende de Rooms
-- =========================================================
CREATE TABLE Shelves (
    Id      INT IDENTITY(1,1) PRIMARY KEY,
    Code    NVARCHAR(50) NOT NULL,
    RoomId  INT NOT NULL,

    CONSTRAINT FK_Shelves_Rooms
        FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO

-- =========================================================
-- 6. READERS — não depende de nada
-- =========================================================
CREATE TABLE Readers (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    FirstName           NVARCHAR(100) NOT NULL,
    LastName            NVARCHAR(100) NOT NULL,
    Email               NVARCHAR(150) NOT NULL,
    RegistrationDate    DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT UQ_Readers_Email UNIQUE (Email)
);
GO

-- =========================================================
-- 7. LIBRARIANS — não depende de nada
-- Entidade transacional/histórica: sem RemoverAsync no C#,
-- desativação é feita via 'Active' (soft-delete), nunca DELETE.
-- =========================================================
CREATE TABLE Librarians (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    FirstName       NVARCHAR(100) NOT NULL,
    LastName        NVARCHAR(100) NOT NULL,
    Username        NVARCHAR(50) NOT NULL,
    PasswordHash    VARBINARY(256) NOT NULL,
    PasswordSalt    VARBINARY(256) NOT NULL,
    Active          BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Librarians_Username UNIQUE (Username)
);
GO

-- =========================================================
-- 8. BOOKS — depende de Authors, Publishers, Categories
-- =========================================================
CREATE TABLE Books (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    ISBN            NVARCHAR(20) NOT NULL,
    Title           NVARCHAR(200) NOT NULL,
    ReleaseDate     DATE NOT NULL,
    Price           DECIMAL(10,2) NOT NULL,
    AuthorId        INT NOT NULL,
    PublisherId     INT NOT NULL,
    CategoryId      INT NOT NULL,

    CONSTRAINT FK_Books_Authors
        FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    CONSTRAINT FK_Books_Publishers
        FOREIGN KEY (PublisherId) REFERENCES Publishers(Id),
    CONSTRAINT FK_Books_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    CONSTRAINT UQ_Books_ISBN UNIQUE (ISBN)
);
GO

-- =========================================================
-- 9. COPIES — depende de Books e Shelves
-- ShelfId é NULL: um exemplar pode ser catalogado antes
-- de ser fisicamente colocado numa prateleira.
-- =========================================================
CREATE TABLE Copies (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Code        NVARCHAR(50) NOT NULL,
    Status      NVARCHAR(20) NOT NULL DEFAULT 'Available',
    BookId      INT NOT NULL,
    ShelfId     INT NULL,

    CONSTRAINT FK_Copies_Books
        FOREIGN KEY (BookId) REFERENCES Books(Id),
    CONSTRAINT FK_Copies_Shelves
        FOREIGN KEY (ShelfId) REFERENCES Shelves(Id),
    CONSTRAINT UQ_Copies_Code UNIQUE (Code),
    CONSTRAINT CK_Copies_Status
        CHECK (Status IN ('Available','Loaned','Reserved','Damaged','Lost'))
);
GO

-- =========================================================
-- 10. LOANS — depende de Copies, Readers, Librarians
-- Entidade histórica: sem DELETE — só INSERT e UPDATE
-- (para registar devolução, atualiza-se ReturnDate).
-- =========================================================
CREATE TABLE Loans (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    LoanDate        DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    DueDate         DATETIME2 NOT NULL,
    ReturnDate      DATETIME2 NULL,
    CopyId          INT NOT NULL,
    ReaderId        INT NOT NULL,
    LibrarianId     INT NOT NULL,

    CONSTRAINT FK_Loans_Copies
        FOREIGN KEY (CopyId) REFERENCES Copies(Id),
    CONSTRAINT FK_Loans_Readers
        FOREIGN KEY (ReaderId) REFERENCES Readers(Id),
    CONSTRAINT FK_Loans_Librarians
        FOREIGN KEY (LibrarianId) REFERENCES Librarians(Id)
);
GO

-- Regra de negócio ao nível da BD: um mesmo exemplar não pode
-- ter dois empréstimos ativos em simultâneo. Índice único FILTRADO
-- (só considera linhas onde ReturnDate ainda é NULL = empréstimo ativo).
CREATE UNIQUE INDEX UQ_Loans_ActiveCopy
    ON Loans(CopyId)
    WHERE ReturnDate IS NULL;
GO

-- =========================================================
-- 11. RESERVATIONS — depende de Readers e Books
-- =========================================================
CREATE TABLE Reservations (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    ReservationDate     DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Status              NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    ReaderId            INT NOT NULL,
    BookId              INT NOT NULL,

    CONSTRAINT FK_Reservations_Readers
        FOREIGN KEY (ReaderId) REFERENCES Readers(Id),
    CONSTRAINT FK_Reservations_Books
        FOREIGN KEY (BookId) REFERENCES Books(Id),
    CONSTRAINT CK_Reservations_Status
        CHECK (Status IN ('Pending','Confirmed','Cancelled'))
);
GO

-- =========================================================
-- 12. FINES — depende de Loans
-- =========================================================
CREATE TABLE Fines (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Amount          DECIMAL(10,2) NOT NULL,
    IssueDate       DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Paid            BIT NOT NULL DEFAULT 0,
    PaymentDate     DATETIME2 NULL,
    LoanId          INT NOT NULL,

    CONSTRAINT FK_Fines_Loans
        FOREIGN KEY (LoanId) REFERENCES Loans(Id)
);
GO