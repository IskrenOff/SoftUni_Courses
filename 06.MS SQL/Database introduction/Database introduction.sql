--01. Create Databese
CREATE DATABASE Minions

--02. Create Tables
CREATE TABLE Minions
(
   Id INT PRIMARY KEY,
   [Name] VARCHAR(50),
   Age INT
)
CREATE TABLE Towns 
(
   Id INT PRIMARY KEY,
   [Name] VARCHAR(50)
)

--03. Alter Minions Table
ALTER TABLE Minions 
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--04. Insert Records in Both Tables
INSERT INTO Towns (Id,[Name])
VALUES 
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')
INSERT INTO Minions (Id,[Name],Age,TownId)
VALUES 
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--05.Truncate Table Minions
TRUNCATE TABLE Minions

--06.Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

--07.Create Table People
CREATE TABLE People 
(
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) NULL,
Height DECIMAL(5,2) NULL,
[Weight] DECIMAL(5,2) NULL,
Gender CHAR(1) NOT NULL CHECK (Gender IN('m','f')),
Birthdata DATE NOT NULL,
Biography NVARCHAR(MAX) NULL
)

INSERT INTO People (Name,Picture,Height,[Weight],Gender,Birthdata,Biography)
VALUES
('Iskren Mirev',NULL,1.85,100.32,'m','1984-11-17','John Doe is a fictional character.'),
('Kalinka Mirev',NULL,1.55,70.12,'m','1986-05-03','John Doe is a fictional character.'),
('Boby Bol',NULL,1.55,111.42,'m','1981-10-07','John Doe is a fictional character.'),
('Ivan Leshnika',NULL,1.25,99.12,'m','1988-01-10','John Doe is a fictional character.'),
('Dimitar Bobara',NULL,1.11,77.72,'m','1991-04-03','John Doe is a fictional character.')

--08.Create Table Users
CREATE TABLE Users
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR(30) NOT NULL UNIQUE,
[Password] VARCHAR(26) NOT NULL UNIQUE,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
)

INSERT INTO Users (Username,[Password])
VALUES
('Iskrenov','asddadsd'),
('Kalinchok','asasdasadsd'),
('Bubka','gergher'),
('Slona','h45h4h'),
('Bastun','089fug08f')