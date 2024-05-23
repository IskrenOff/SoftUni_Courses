USE SoftUni

-- 01. Find Names of All Employees by First Name
SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'SA%'

-- 02. Find Names of All Employees by Last Name 
SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employees 
SELECT FirstName 
  FROM Employees
 WHERE DepartmentID IN (3,10) AND CAST(DATEPART(Year, HireDate) AS INT) BETWEEN 1995 AND 2005

-- 04. Find All Employees Except Engineers 
SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'  

 -- 05. Find Towns with Name Length 
  SELECT [Name] 
    FROM Towns
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

-- 06. Find Towns Starting With
  SELECT TownID, [Name]
    FROM Towns
   WHERE [Name] LIKE '[M,K,B,E]%'
ORDER BY [Name]

-- 07. Find Towns Not Starting With 
  SELECT TownID, [Name]
    FROM Towns
   WHERE [Name] NOT LIKE '[R,B,D]%'
ORDER BY [Name]

-- 08. Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000
         AS
     SELECT FirstName, LastName
       FROM Employees
	  WHERE CAST(DATEPART(YEAR, HireDate) AS INT) > 2000
GO

-- 09. Length of Last Name 
SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5

-- 10. Rank Employees by Salary 
  SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11. Find All Employees with Rank 2
SELECT * FROM
   (SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
     FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000) AS temp
   WHERE temp.[Rank] = 2
ORDER BY temp.Salary DESC

USE [Geography]
-- 12. Countries Holding 'A' 3 or More Times 
  SELECT CountryName, IsoCode FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode