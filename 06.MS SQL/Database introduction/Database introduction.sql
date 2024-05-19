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

--09.Change Primery Key
ALTER TABLE Users 
DROP CONSTRAINT PK__Users__3214EC0784A1B265

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id,Username)

--10.Add check constarint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password_lenght CHECK (LEN(Password) >= 5)

--11.Set defold value of field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--12.Set unique field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username_Lenght CHECK (LEN(Username) >= 3)

--13.Move Database
CREATE DATABASE [Movies]

CREATE TABLE [Directors]
(
   [Id] INT IDENTITY(1,1) PRIMARY KEY,
   [DirectorName] VARCHAR(50),
   [Notes] NVARCHAR(MAX)
)
CREATE TABLE [Genres]
(
   [Id] INT IDENTITY(1,1) PRIMARY KEY,
   [GenreName] VARCHAR(50),
   [Notes] NVARCHAR(MAX)
)
CREATE TABLE [Categories]
(
   [Id] INT IDENTITY(1,1) PRIMARY KEY,
   [CategoryName] VARCHAR(50),
   [Notes] NVARCHAR(MAX)
)
CREATE TABLE [Movies]
(
   [Id] INT IDENTITY(1,1) PRIMARY KEY,
   [Title] VARCHAR(50) NOT NULL,
   [DirectorId] INT ,
   [CopyrightYear] INT NOT NULL,
   [Length] INT, 
   [GenreId] INT NOT NULL,
   [CategoryId] INT NOT NULL,
   [Rating] VARCHAR(10),
   [Notes] TEXT,
   CONSTRAINT FK_Movies_Director FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
   CONSTRAINT FK_Movies_Genres FOREIGN KEY (GenreId) REFERENCES Genres(Id),
   CONSTRAINT FK_Movies_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Directors (DirectorName,Notes)
VALUES
('Director1','Long notes 1'),
('Director2','Long notes 2'),
('Director3','Long notes 3'),
('Director4','Long notes 4'),
('Director5','Long notes 5')

INSERT INTO Genres (GenreName,Notes)
VALUES
('Genre1','Long notes 1'),
('Genre2','Long notes 2'),
('Genre3','Long notes 3'),
('Genre4','Long notes 4'),
('Genre5','Long notes 5')

INSERT INTO Categories (CategoryName,Notes)
VALUES
('CategoryName1', 'Very Long note1'),
('CategoryName2', 'Very Long note2'),
('CategoryName3', 'Very Long note3'),
('CategoryName4', 'Very Long note4'),
('CategoryName5', 'Very Long note5')

INSERT INTO Movies (Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId,Rating,Notes)
VALUES
('Movie1',1,2001,141,1,1,'PG-1','Long notes'),
('Movie2',2,2002,142,2,2,'PG-2','Long notes'),
('Movie3',3,2003,143,3,3,'PG-3','Long notes'),
('Movie4',4,2004,144,4,4,'PG-4','Long notes'),
('Movie5',5,2005,145,5,5,'PG-5','Long notes')

--14.Car rental Db
CREATE DATABASE [CarRental]

CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories (CategoryName) VALUES
    ('Truck'),
	('Car'),
	('Bus')

--SELECT * FROM Categories

CREATE TABLE Cars(
    Id INT PRIMARY KEY IDENTITY(1,1),
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50),
	CarYear INT,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT
)

INSERT INTO Cars(PlateNumber, CategoryId, Manufacturer) VALUES
    (55, 1, 'BMW'),
	(51, 2, 'Audi'),
	(50, 3, 'Merz')

--SELECT * FROM Cars

CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY (1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(MAX),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName) VALUES
    ('Ivan', 'Ivanov'),
    ('Gosho', 'Goshov'),
	('Marto', 'Martev')

--SELECT * FROM Employees

CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(100),
	City NVARCHAR(50),
	ZIPCode INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName) VALUES
    (44, 'Pesho ivanov'),
	(33, 'Ivan ivanov'),
	(22, 'Georgi ivanov')

--SELECT * FROM Customers

CREATE TABLE RentalOrders(
    Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, KilometrageStart) VALUES
    (1, 2, 3, 200),
	(2, 3, 2, 2000),
	(3, 1, 1, 20000)

--15. Hotel Database
CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName) VALUES
    ('Ivan', 'Ivanov'),
	('Georgi', 'Don'),
	('Toni', 'Ton')

--SELECT * FROM Employees

CREATE TABLE Customers(
    AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber VARCHAR(12),
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES
    (55, 'Pesho', 'Ivanov', '0959759957'), 
	(44, 'Gosho', 'Sasg', '1232435354'),
	(33, 'Alek', 'Ivanov', '0954345427')

--SELECT * FROM Customers

CREATE TABLE RoomStatus(
    RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus) VALUES
    ('Full'),
	('Empty'),
	('Half')

--SELECT * FROM RoomStatus

CREATE TABLE RoomTypes(
    RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType) VALUES
    ('Large'),
	('Medium'),
	('Small')

--SELECT * FROM RoomTypes

CREATE TABLE BedTypes(
    BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType) VALUES
    ('Double'),
	('Single'),
	('Family')

--SELECT * FROM BedTypes

CREATE TABLE Rooms(
    RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate INT,
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus) VALUES
    (1, 'Large', 'Double', 'Full'),
	(2, 'Medium', 'Single', 'Half'),
	(3, 'Small', 'Family', 'Empty')

--SELECT * FROM Rooms

CREATE TABLE Payments(
    Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE,
	AccountNumber INT,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(15,2),
	TaxRate INT,
	TaxAmount DECIMAL(15,2),
	PaymentTotal DECIMAL(15,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId) VALUES
    (1),
	(2),
	(3)

--SELECT * FROM Payments

CREATE TABLE Occupancies(
    Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber) VALUES
    (1, 55, 1),
	(2, 44, 2),
	(3, 33, 3)

--19. Basic Insert
CREATE DATABASE SoftUni

CREATE TABLE Towns(
    Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
    Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
    Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE,
	Salary DECIMAL(15,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)


INSERT INTO Towns ([Name]) VALUES
    ('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments ([Name]) VALUES
    ('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',	4,	CONVERT(datetime, '01/02/2013', 103), 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1,	CONVERT(datetime, '02/03/2004', 103), 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern',	5,	CONVERT(datetime, '28/08/2016', 103), 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO',	2,	CONVERT(datetime, '09/12/2007', 103), 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern',	3,	CONVERT(datetime, '28/08/2016', 103), 599.88)

--Exercise 19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Exercise 20
SELECT * FROM Towns
ORDER BY [Name]
SELECT * FROM Departments
ORDER BY [Name]
SELECT * FROM Employees
ORDER BY Salary DESC

--Exercise 21

SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY SALARY DESC

--Exercise 22

UPDATE Employees
SET Salary+=Salary*0.1

SELECT Salary FROM Employees

--Exercise 23 

UPDATE Payments
SET TaxRate-=0.03*TaxRate

SELECT TaxRate FROM Payments

--Exercise 24
TRUNCATE TABLE Occupancies
DELETE FROM Occupancies




