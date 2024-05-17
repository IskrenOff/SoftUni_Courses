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

CREATE TABLE [Categories]
(
  [Id] INT IDENTITY(1,1) PRIMARY KEY,
  [CategoryName] VARCHAR(50) NOT NULL,
  [DailyRate] DECIMAL(10,2) NOT NULL,
  [WeeklyRate] DECIMAL(10,2) NOT NULL,
  [MonthlyRate] DECIMAL(10,2) NOT NULL,
  [WeekendRate] DECIMAL(10,2) NOT NULL,
)

CREATE TABLE [Cars]
(
  [Id] INT IDENTITY(1,1) PRIMARY KEY,
  [PlateNumber] VARCHAR(20) NOT NULL,
  [Manufacturer] VARCHAR(50) NOT NULL,
  [Model] VARCHAR(50) NOT NULL,
  [CarYear] INT NOT NULL,
  [CategoryId] INT NOT NUll,
  [Doors] INT NOT NULL,
  [Picture] VARBINARY(MAX),
  [Condition] VARCHAR(100),
  [Available] BIT,
  CONSTRAINT FK_Cars_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE [Employees]
(
  [Id] INT IDENTITY(1,1) PRIMARY KEY,
  [FirstName] VARCHAR(20) NOT NULL,
  [LastName] VARCHAR(20) NOT NULL,
  [Title] VARCHAR(100),
  [Notes] TEXT
)

CREATE TABLE [Customers]
(
  [Id] INT IDENTITY(1,1) PRIMARY KEY,
  [DriverLicenseNumber] INT NOT NULL,
  [FullName] VARCHAR(50) NOT NULL,
  [Address] VARCHAR(100) NOT NULL,
  [City] VARCHAR(30) NOT NULL,
  [ZIPCode] INT NOT NULL,
  [Notes] TEXT
)

CREATE TABLE [RentalOrders]
(
  [Id] INT IDENTITY(1,1) PRIMARY KEY,
  [EmployeeId] INT NOT NULL,
  [CustomerId] INT NOT NULL,
  [CarId] INT NOT NULL,
  [TankLevel] DECIMAL(10,2),
  [KilometerRangeStart] DECIMAL(10,2),
  [KilometerRangeEnd] DECIMAL(10,2),
  [TotalKilometerRange] DECIMAL(10,2),
  [StartDate] DATETIME2 NOT NULL,
  [EndDate] DATETIME2 NOT NULL,
  [TotalDays] INT NOT NULL,
  [RateApplied] DECIMAL(10,2) NOT NULL,
  [TaxRate] DECIMAL(5,2),
  [OrderStatus] VARCHAR(50),
  [Notes] TEXT,
  CONSTRAINT FK_RentalOredrs_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
  CONSTRAINT FK_RentalOredrs_Customer FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
  CONSTRAINT FK_RentalOredrs_Car FOREIGN KEY (CarId) REFERENCES Cars(Id)
)



INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Economy', 25.00, 150.00, 500.00, 40.00),
('Compact', 30.00, 180.00, 600.00, 45.00),
('SUV', 40.00, 240.00, 800.00, 55.00)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available) 
VALUES
('ABC123', 'Toyota', 'Corolla', 2019, 1, 4, 1),
('XYZ789', 'Honda', 'Civic', 2020, 2, 4, 1),
('DEF456', 'Ford', 'Escape', 2018, 3, 4, 1)

INSERT INTO Employees (FirstName, LastName, Title) 
VALUES
('John', 'Doe', 'Manager'),
('Jane', 'Smith', 'Sales Associate'),
('Michael', 'Johnson', 'Customer Service Representative')

INSERT INTO Customers (DriverLicenseNumber, FullName, Address, City, ZIPCode) 
VALUES
('DL123456', 'Alice Johnson', '123 Main St', 'New York', '10001'),
('DL654321', 'Bob Smith', '456 Elm St', 'Los Angeles', '90001'),
('DL987654', 'Charlie Brown', '789 Oak St', 'Chicago', '60601')


INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometerRangeStart, KilometerRangeEnd, TotalKilometerRange, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(4, 2, 3, 50.00, 100.00, 200.00, 100.00, '2024-05-01 08:00:00', '2024-05-03 18:00:00', 3, 75.00, 0.2, 'Completed', 'Notes for order 1'),
(5, 3, 4, 60.00, 150.00, 250.00, 100.00, '2024-05-02 09:00:00', '2024-05-04 16:00:00', 2, 90.00, 0.2, 'Completed', 'Notes for order 2'),
(6, 4, 5, 70.00, 200.00, 300.00, 100.00, '2024-05-03 10:00:00', '2024-05-06 14:00:00', 3, 120.00, 0.2, 'In Progress', 'Notes for order 3');


ALTER TABLE RentalOrders
ALTER COLUMN [EndDate] DATETIME2 NOT NULL

SELECT * FROM RentalOrders
TRUNCATE TABLE RentalOrders


DELETE FROM RentalOrders
WHERE Id IN (
    SELECT TOP 3 Id
    FROM RentalOrders
    ORDER BY Id DESC
)
