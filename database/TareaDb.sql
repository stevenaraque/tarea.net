-- Crear base de datos TareaDb
IF DB_ID('TareaDb') IS NULL
    CREATE DATABASE TareaDb;
GO

USE TareaDb;
GO

IF OBJECT_ID('dbo.Tareas', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tareas (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Titulo NVARCHAR(200) NOT NULL,
        Descripcion NVARCHAR(500) NULL,
        Completada BIT NOT NULL DEFAULT 0,
        FechaCreacion DATETIME2 NOT NULL DEFAULT GETUTCDATE()
    );
END
GO
