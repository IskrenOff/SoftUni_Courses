USE SoftUni

-- 01. Employee Address 
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
    FROM Employees AS e
    JOIN Addresses AS a
      ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- 02. Addresses with Towns 
SELECT TOP(50) 
	e.FirstName, 
	e.LastName, 
	t.[Name] AS [Town], 
	a.AddressText 
	FROM Employees AS e
		LEFT JOIN Addresses AS a 
	    ON e.AddressID = a.AddressID
	    LEFT JOIN Towns AS t 
	    ON t.TownID = a.TownID 
ORDER BY FirstName, LastName

-- 03. Sales Employees 
  SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName]
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID 

-- 04. Employee Departments 
  SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name] AS [DepartmentName]
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
   WHERE Salary > 15000
ORDER BY e.DepartmentID

-- 05. Employees Without Projects 
  SELECT TOP(3) e.EmployeeID, e.FirstName
    FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
	  ON ep.EmployeeID = e.EmployeeID
   WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

SELECT * FROM Projects

-- 06. Employees Hired After 
  SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
    FROM Employees AS e
    JOIN Departments AS d
	  ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Sales', 'Finance')
   WHERE e.HireDate > '1/1/1999'
ORDER BY e.HireDate

-- 07. Employees With Project
  SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
    FROM Employees AS e
    JOIN EmployeesProjects AS ep
      ON e.EmployeeID = ep.EmployeeID
    JOIN Projects AS p
      ON p.ProjectID = ep.ProjectID
   WHERE p.EndDate IS NULL AND p.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

SELECT * FROM Projects

-- 08. Employee 24 
SELECT e.EmployeeID,
       e.FirstName, 
	   CASE WHEN p.StartDate >= '2005-01-01' THEN NULL
	   ELSE p.[Name]
	   END AS [ProjectName]
  FROM Employees AS e
  JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID AND e.EmployeeID = 24
  JOIN Projects AS p
    ON p.ProjectID = ep.ProjectID

-- instead of case when  IIF(p.StartDate >= '2005-01-01', NULL, p.[Name]) AS [ProjectName]

-- 09. Employee Manager 
  SELECT e1.EmployeeID, e1.FirstName, e1.ManagerID, e2.FirstName AS [ManagerName] 
    FROM Employees AS e1
    JOIN Employees AS e2
      ON e1.ManagerID = e2.EmployeeID
   WHERE e2.EmployeeID IN (3, 7)
ORDER BY e1.EmployeeID

-- 10. Employees Summary 
  SELECT TOP(50) e1.EmployeeID, 
         CONCAT(e1.FirstName, ' ', e1.LastName) AS [EmployeeName],
		 CONCAT(e2.FirstName, ' ', e2.LastName) AS [ManagerName],
		 d.[Name] AS [DepartmentName]
    FROM Employees AS e1
LEFT JOIN Employees AS e2
	  ON e1.ManagerID = e2.EmployeeID
LEFT JOIN Departments AS d
	  ON d.DepartmentID = e1.DepartmentID
ORDER BY e1.EmployeeID

-- 11. Min Average Salary 
SELECT MIN(av.[AverageSalary]) AS [MinAverageSalary] 
 FROM(
      SELECT AVG(e.Salary) AS [AverageSalary] 
	    FROM Employees AS e
    GROUP BY DepartmentID ) AS av
	
USE [Geography]

-- 12. Highest Peaks in Bulgaria 
  SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
    FROM Peaks AS p
    JOIN Mountains AS m
      ON p.MountainId = m.Id
    JOIN MountainsCountries AS mc
      ON mc.MountainId = m.Id
   WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges
  SELECT CountryCode, COUNT(MountainId) AS [MountainRanges]
    FROM MountainsCountries
GROUP BY CountryCode
  HAVING CountryCode IN ('BG', 'RU', 'US')

-- 14. Countries With or Without Rivers 
   SELECT TOP(5) c.CountryName, r.RiverName 
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
       ON r.Id = cr.RiverId
    WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName
	 
-- 15. Continents and Currencies
 SELECT dt.ContinentCode, dt.CurrencyCode, dt.CurrencyUsage 
   FROM
        (SELECT c.ContinentCode, 
                c.CurrencyCode, 
		        COUNT(c.CurrencyCode) AS [CurrencyUsage],
		        DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
           FROM Countries AS c
       GROUP BY c.ContinentCode, c.CurrencyCode
         HAVING COUNT(c.CurrencyCode) > 1) AS dt
   WHERE dt.[Rank] = 1
ORDER BY dt.ContinentCode

-- 16. Countries Without any Mountains 
SELECT COUNT(*) 
  FROM  (
       SELECT c.CountryName FROM Countries AS c
    LEFT JOIN MountainsCountries AS mc
           ON c.CountryCode = mc.CountryCode
	    WHERE mc.MountainId IS NULL) AS dt

-- 17. Highest Peak and Longest River by Country
   SELECT TOP(5) dt.CountryName, MAX(dt.Elevation) AS [HighestPeakElevation], MAX(dt.[Length]) AS [LongestRiverLength]
     FROM(
   SELECT c.CountryName, r.[Length], p.Elevation
     FROM Countries c
LEFT JOIN MountainsCountries mc
       ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
       ON m.Id = mc.MountainId
LEFT JOIN Peaks p
       ON p.MountainId = m.Id
LEFT JOIN CountriesRivers cr
       ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
       ON r.Id = cr.RiverId) AS dt
 GROUP BY dt.CountryName
 ORDER BY MAX(dt.Elevation) DESC, MAX(dt.[Length]) DESC, dt.CountryName

-- 18. Highest Peak Name and Elevation by Country
SELECT TOP(5) dt.CountryName AS[Country],
       IIF(dt.PeakName IS NULL, '(no highest peak)', dt.PeakName) AS [Highest Peak Name],
	   ISNULL(dt.Elevation, 0) AS [Highest Peak Elevation],
	   IIF(dt.MountainRange IS NULL, '(no mountain)', dt.MountainRange) AS [Mountain]
  FROM
       (SELECT c.CountryName,
               p.PeakName,
	           p.Elevation,
	           m.MountainRange,
		       DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Ranking]
          FROM Countries c
     LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
     LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
     LEFT JOIN Peaks AS p ON p.MountainId = m.Id) AS dt
   WHERE dt.Ranking = 1
ORDER BY dt.CountryName, dt.PeakName