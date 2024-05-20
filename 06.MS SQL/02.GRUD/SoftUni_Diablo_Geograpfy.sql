-- SOFTUNI Db
--2. Find All the Information About Departments
SELECT * FROM Departments

--3. Find all Department Names
SELECT [Name] FROM Departments

--4. Find Salary of Each Employee
SELECT FirstName, LastName, Salary FROM Employees

--5. Find Full Name of Each Employee
SELECT FirstName, MiddleName, LastName FROM Employees

--6. Find Email Address of Each Employee
SELECT FirstName + '.' + LastName + '@softuni.bg' 
    AS [Full Email Address]
  FROM Employees

--7. Find All Different Employees' Salaries
SELECT DISTINCT Salary FROM Employees

--8. Find All Information About Employees
SELECT * FROM Employees
    WHERE JobTitle = 'Sales Representative'

--9. Find Names of All Employees by Salary in Range
SELECT FirstName, LastName, JobTitle 
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

--10. Find Names of All Employees
SELECT CONCAT(FirstName, ' ',  MiddleName + ' ', LastName) 
    AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600)

--11. Find All Employees Without a Manager
SELECT FirstName, LastName 
  FROM Employees
 WHERE ManagerID IS NULL