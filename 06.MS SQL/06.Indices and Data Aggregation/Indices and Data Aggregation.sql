USE Gringotts

-- 01. Records� Count
SELECT COUNT(*) AS [Count]
  FROM WizzardDeposits

-- 02. Longest Magic Wand
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits

-- 03. Longest Magic Wand per Deposit Groups 
  SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits
GROUP BY DepositGroup

-- Exercise 4
  SELECT TOP(2) DepositGroup
    FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- Exercise 5
  SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
    FROM WizzardDeposits w
GROUP BY w.DepositGroup

-- Exercise 6
  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- Exercise 7
  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits w
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- Exercise 8
  SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- Exercise 9
SELECT 
CASE 
	 WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	 WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	 WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	 WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	 WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	 WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	 ELSE '[61+]'
END AS [AgeGroup], COUNT(*) AS [WizardCount]
  FROM WizzardDeposits
GROUP BY CASE 
	 WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	 WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	 WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	 WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	 WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	 WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	 ELSE '[61+]'
END

-- Exercise 10
  SELECT LEFT(FirstName, 1) 
      AS [FirstLetter] 
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY [FirstLetter]

-- 11. Average Interest 
  SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) 
    FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- 12. *Rich Wizard, Poor Wizard
SELECT SUM([Difference]) AS [SumDifference] FROM (SELECT FirstName AS [Host Wizard],
       DepositAmount AS [Host Wizard Deposit],
	   LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
	   LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
	   DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
	   FROM WizzardDeposits) AS DiffTable	  

USE SoftUni

-- 13. Departments Total Salaries 
  SELECT DepartmentID, SUM(Salary) AS [TotalSalary] 
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14. Employees Minimum Salaries
  SELECT DepartmentID, MIN(Salary)
    FROM Employees
   WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

-- 15. Employees Average Salaries 
SELECT * 
  INTO [New employees Table]
  FROM Employees
 WHERE Salary > 30000

DELETE FROM [New employees Table]
WHERE ManagerID = 42

UPDATE [New employees Table]
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT DepartmentID, AVG(Salary) AS [AverageSalary] 
    FROM [New employees Table]
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries 
  SELECT DepartmentID, MAX(Salary) AS [MaxSalary] 
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- 17. Employees Count Salaries 
SELECT COUNT(Salary) AS [Count]
  FROM Employees
 WHERE ManagerID IS NULL

-- 18. *3rd Highest Salary
SELECT DISTINCT DepartmentID, Salary AS [ThirdHighestSalary] 
  FROM(
		SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank] FROM Employees
      )
    AS [Rank Table]
WHERE [Rank] = 3

SELECT DepartmentID, Salary AS [ThirdHighestSalary] FROM
		(SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
			FROM Employees
			GROUP BY DepartmentID, Salary) AS [Rank Table]
WHERE Ranking = 3

-- 19. **Salary Challenge
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
  FROM Employees AS e
 WHERE e.Salary > (
					SELECT AVG(Salary) 
					FROM Employees AS m
					WHERE m.DepartmentID = e.DepartmentID
					GROUP BY DepartmentID
				)
ORDER BY e.DepartmentID