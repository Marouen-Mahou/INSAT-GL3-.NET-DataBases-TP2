
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2021 11:07:51
-- Generated from EDMX file: C:\Users\asus\source\repos\INSAT GL3 TP2\EF-ModelFirst\ModelFirstTP2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gl3tp2Act1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Marque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voitures] DROP CONSTRAINT [FK_Marque];
GO
IF OBJECT_ID(N'[dbo].[FK_Proprietaire]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voitures] DROP CONSTRAINT [FK_Proprietaire];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[marques]', 'U') IS NOT NULL
    DROP TABLE [dbo].[marques];
GO
IF OBJECT_ID(N'[dbo].[personnes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[personnes];
GO
IF OBJECT_ID(N'[dbo].[voitures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[voitures];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'marques'
CREATE TABLE [dbo].[marques] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(20)  NOT NULL
);
GO

-- Creating table 'personnes'
CREATE TABLE [dbo].[personnes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(20)  NOT NULL,
    [Prénom] varchar(20)  NOT NULL
);
GO

-- Creating table 'voitures'
CREATE TABLE [dbo].[voitures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Modele] varchar(20)  NOT NULL,
    [Marque] int  NOT NULL,
    [Proprietaire] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'marques'
ALTER TABLE [dbo].[marques]
ADD CONSTRAINT [PK_marques]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'personnes'
ALTER TABLE [dbo].[personnes]
ADD CONSTRAINT [PK_personnes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [PK_voitures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Marque] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [FK_Marque]
    FOREIGN KEY ([Marque])
    REFERENCES [dbo].[marques]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Marque'
CREATE INDEX [IX_FK_Marque]
ON [dbo].[voitures]
    ([Marque]);
GO

-- Creating foreign key on [Proprietaire] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [FK_Proprietaire]
    FOREIGN KEY ([Proprietaire])
    REFERENCES [dbo].[personnes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Proprietaire'
CREATE INDEX [IX_FK_Proprietaire]
ON [dbo].[voitures]
    ([Proprietaire]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------