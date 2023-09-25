ALTER TABLE dbo.Employees
ADD Age AS DATEDIFF(YEAR, BirthDate, GETDATE());


DELETE FROM Employees
WHERE Age > 70;