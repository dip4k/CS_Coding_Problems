## SQL Topics

### **1. Basic SQL Queries**

**Select Query**

```sql
SELECT * FROM Employees;
```

**Filtering Data**

```sql
SELECT Name, Salary
FROM Employees
WHERE Salary > 50000;
```

**Sorting Data**

```sql
SELECT Name, Salary
FROM Employees
ORDER BY Salary DESC;
```

### **2. Aggregate Functions**

**Count**

```sql
SELECT COUNT(*) AS EmployeeCount
FROM Employees;
```

**Sum**

```sql
SELECT SUM(Salary) AS TotalSalary
FROM Employees;
```

**Average**

```sql
SELECT AVG(Salary) AS AverageSalary
FROM Employees;
```

**Group By**

```sql
SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentID;
```

### **3. Joins**

**Inner Join**

```sql
SELECT e.Name, d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

**Left Join**

```sql
SELECT e.Name, d.DepartmentName
FROM Employees e
LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

**Right Join**

```sql
SELECT e.Name, d.DepartmentName
FROM Employees e
RIGHT JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

**Full Outer Join**

```sql
SELECT e.Name, d.DepartmentName
FROM Employees e
FULL OUTER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

### **4. Subqueries**

**Subquery in WHERE Clause**

```sql
SELECT Name
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);
```

**Subquery in FROM Clause**

```sql
SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM (SELECT DepartmentID, Salary FROM Employees) AS Subquery
GROUP BY DepartmentID;
```

### **5. Common Table Expressions (CTEs)**

**Simple CTE**

```sql
WITH EmployeeCTE AS (
    SELECT Name, Salary
    FROM Employees
)
SELECT * FROM EmployeeCTE;
```

**CTE for Ranking**

```sql
WITH SalaryRank AS (
    SELECT Name, Salary,
           DENSE_RANK() OVER (ORDER BY Salary DESC) AS Rank
    FROM Employees
)
SELECT Name, Salary
FROM SalaryRank
WHERE Rank = 2;
```

### **6. Window Functions**

**Row Number**

```sql
SELECT Name, Salary,
       ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNum
FROM Employees;
```

**Cumulative Sum**

```sql
SELECT Name, Salary,
       SUM(Salary) OVER (ORDER BY HireDate) AS CumulativeSalary
FROM Employees;
```

### **7. Handling NULL Values**

**IS NULL**

```sql
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL;
```

**COALESCE**

```sql
SELECT Name, COALESCE(ManagerID, 'No Manager') AS ManagerID
FROM Employees;
```

### **8. Data Modification**

**Insert**

```sql
INSERT INTO Employees (Name, Salary, DepartmentID)
VALUES ('John Doe', 60000, 1);
```

**Update**

```sql
UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Sales');
```

**Delete**

```sql
DELETE FROM Employees
WHERE LastActiveDate < '2020-01-01';
```

### **9. Stored Procedures**

**Simple Stored Procedure**

```sql
CREATE PROCEDURE GetEmployeeDetails
    @EmployeeID INT
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;
```

### **10. Indexing**

**Creating an Index**

```sql
CREATE INDEX idx_employee_name ON Employees(Name);
```

**Dropping an Index**

```sql
DROP INDEX idx_employee_name ON Employees;
```

### **11. Transactions**

**Transaction with Commit**

```sql
BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentID = 1;

COMMIT;
```

**Transaction with Rollback**

```sql
BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentID = 1;

ROLLBACK;
```

### **12. Advanced Topics**

**Pivot Table**

```sql
SELECT *
FROM (
    SELECT DepartmentID, Name, Salary
    FROM Employees
) AS SourceTable
PIVOT (
    SUM(Salary)
    FOR DepartmentID IN ([1], [2], [3])
) AS PivotTable;
```

**Recursive CTE**

```sql
WITH EmployeeHierarchy AS (
    SELECT EmployeeID, Name, ManagerID
    FROM Employees
    WHERE ManagerID IS NULL
    UNION ALL
    SELECT e.EmployeeID, e.Name, e.ManagerID
    FROM Employees e
    INNER JOIN EmployeeHierarchy eh ON e.ManagerID = eh.EmployeeID
)
SELECT * FROM EmployeeHierarchy;
```

**Temporary Tables**

```sql
CREATE TABLE #TempEmployees (
    EmployeeID INT,
    Name NVARCHAR(50),
    Salary DECIMAL(10, 2)
);

INSERT INTO #TempEmployees (EmployeeID, Name, Salary)
SELECT EmployeeID, Name, Salary
FROM Employees
WHERE DepartmentID = 1;

SELECT * FROM #TempEmployees;

DROP TABLE #TempEmployees;
```

**Dynamic SQL**

```sql
DECLARE @sql NVARCHAR(MAX);
SET @sql = 'SELECT * FROM Employees WHERE DepartmentID = @DeptID';
EXEC sp_executesql @sql, N'@DeptID INT', @DeptID = 1;
```

### **13. JSON Data Handling**

**Parsing JSON Data**

```sql
DECLARE @json NVARCHAR(MAX) = N'[
    {"EmployeeID": 1, "Name": "John Doe", "Salary": 60000},
    {"EmployeeID": 2, "Name": "Jane Smith", "Salary": 70000}
]';

SELECT *
FROM OPENJSON(@json)
WITH (
    EmployeeID INT,
    Name NVARCHAR(50),
    Salary DECIMAL(10, 2)
);
```

### **14. XML Data Handling**

**Parsing XML Data**

```sql
DECLARE @xml XML = '<Employees>
    <Employee>
        <EmployeeID>1</EmployeeID>
        <Name>John Doe</Name>
        <Salary>60000</Salary>
    </Employee>
    <Employee>
        <EmployeeID>2</EmployeeID>
        <Name>Jane Smith</Name>
        <Salary>70000</Salary>
    </Employee>
</Employees>';

SELECT
    Employee.value('(EmployeeID)[1]', 'INT') AS EmployeeID,
    Employee.value('(Name)[1]', 'NVARCHAR(50)') AS Name,
    Employee.value('(Salary)[1]', 'DECIMAL(10, 2)') AS Salary
FROM @xml.nodes('/Employees/Employee') AS EmployeeTable(Employee);
```

### **15. Performance Tuning**

**Query Execution Plan**

```sql
-- Enable the execution plan
SET SHOWPLAN_ALL ON;

SELECT Name, Salary
FROM Employees
WHERE Salary > 50000;

-- Disable the execution plan
SET SHOWPLAN_ALL OFF;
```

**Index Usage**

```sql
-- Create an index
CREATE INDEX idx_employee_salary ON Employees(Salary);

-- Query using the index
SELECT Name, Salary
FROM Employees
WHERE Salary > 50000;
```

### **16. Data Integrity**

**Foreign Key Constraint**

```sql
ALTER TABLE Employees
ADD CONSTRAINT FK_Department
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID);
```

**Check Constraint**

```sql
ALTER TABLE Employees
ADD CONSTRAINT CHK_Salary
CHECK (Salary >= 0);
```

### **17. Data Definition Language (DDL)**

**Create Table**

```sql
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Salary DECIMAL(10, 2),
    DepartmentID INT
);
```

**Alter Table**

```sql
ALTER TABLE Employees
ADD HireDate DATE;
```

**Drop Table**

```sql
DROP TABLE Employees;
```

### **18. Views**

**Create View**

```sql
CREATE VIEW EmployeeView AS
SELECT e.Name, e.Salary, d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
```

**Query View**

```sql
SELECT * FROM EmployeeView;
```

**Drop View**

```sql
DROP VIEW EmployeeView;
```

### **19. User-Defined Functions**

**Scalar Function**

```sql
CREATE FUNCTION GetEmployeeSalary(@EmployeeID INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Salary DECIMAL(10, 2);
    SELECT @Salary = Salary
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
    RETURN @Salary;
END;
```

**Table-Valued Function**

```sql
CREATE FUNCTION GetEmployeesByDepartment(@DepartmentID INT)
RETURNS TABLE
AS
RETURN (
    SELECT EmployeeID, Name, Salary
    FROM Employees
    WHERE DepartmentID = @DepartmentID
);
```

### **20. Triggers**

**After Insert Trigger**

```sql
CREATE TRIGGER trgAfterInsert
ON Employees
AFTER INSERT
AS
BEGIN
    DECLARE @EmployeeID INT, @Name NVARCHAR(50), @Salary DECIMAL(10, 2);

    SELECT @EmployeeID = EmployeeID, @Name = Name, @Salary = Salary
    FROM inserted;

    INSERT INTO EmployeeAudit (EmployeeID, Name, Salary, Action, ActionDate)
    VALUES (@EmployeeID, @Name, @Salary, 'INSERT', GETDATE());
END;
```

**After Update Trigger**

```sql
CREATE TRIGGER trgAfterUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    DECLARE @EmployeeID INT, @OldSalary DECIMAL(10, 2), @NewSalary DECIMAL(10, 2);

    SELECT @EmployeeID = EmployeeID, @OldSalary = deleted.Salary, @NewSalary = inserted.Salary
    FROM inserted
    JOIN deleted ON inserted.EmployeeID = deleted.EmployeeID;

    INSERT INTO EmployeeAudit (EmployeeID, OldSalary, NewSalary, Action, ActionDate)
    VALUES (@EmployeeID, @OldSalary, @NewSalary, 'UPDATE', GETDATE());
END;
```

**After Delete Trigger**

```sql
CREATE TRIGGER trgAfterDelete
ON Employees
AFTER DELETE
AS
BEGIN
    DECLARE @EmployeeID INT, @Name NVARCHAR(50), @Salary DECIMAL(10, 2);

    SELECT @EmployeeID = EmployeeID, @Name = Name, @Salary = Salary
    FROM deleted;

    INSERT INTO EmployeeAudit (EmployeeID, Name, Salary, Action, ActionDate)
    VALUES (@EmployeeID, @Name, @Salary, 'DELETE', GETDATE());
END;
```

### **21. Advanced Analytical Functions**

**LEAD and LAG**

```sql
SELECT
    EmployeeID,
    Name,
    Salary,
    LAG(Salary, 1, 0) OVER (ORDER BY Salary) AS PreviousSalary,
    LEAD(Salary, 1, 0) OVER (ORDER BY Salary) AS NextSalary
FROM Employees;
```

**NTILE**

```sql
SELECT
    EmployeeID,
    Name,
    Salary,
    NTILE(4) OVER (ORDER BY Salary) AS Quartile
FROM Employees;
```

### **22. Full-Text Search**

**Creating Full-Text Index**

```sql
CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;
CREATE FULLTEXT INDEX ON Employees(Name) KEY INDEX PK_EmployeeID;
```

**Using Full-Text Search**

```sql
SELECT *
FROM Employees
WHERE CONTAINS(Name, 'John');
```

### **23. Security**

**Creating a User**

```sql
CREATE LOGIN TestUser WITH PASSWORD = 'StrongPassword123!';
CREATE USER TestUser FOR LOGIN TestUser;
```

**Granting Permissions**

```sql
GRANT SELECT ON Employees TO TestUser;
```

**Revoking Permissions**

```sql
REVOKE SELECT ON Employees FROM TestUser;
```

### **24. Backup and Restore**

**Backup Database**

```sql
BACKUP DATABASE MyDatabase
TO DISK = 'C:\Backups\MyDatabase.bak';
```

**Restore Database**

```sql
RESTORE DATABASE MyDatabase
FROM DISK = 'C:\Backups\MyDatabase.bak';
```

### **25. Partitioning**

**Creating a Partition Function**

```sql
CREATE PARTITION FUNCTION MyRangePF1 (int)
AS RANGE LEFT FOR VALUES (1, 100, 1000);
```

**Creating a Partition Scheme**

```sql
CREATE PARTITION SCHEME MyRangePS1
AS PARTITION MyRangePF1
TO (filegroup1, filegroup2, filegroup3, filegroup4);
```

**Creating a Partitioned Table**

```sql
CREATE TABLE PartitionedTable (
    ID INT,
    Name NVARCHAR(50)
) ON MyRangePS1(ID);
```

### **26. Error Handling**

**TRY...CATCH Block**

```sql
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Employees
    SET Salary = Salary * 1.10
    WHERE DepartmentID = 1;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
```

### **27. Data Encryption**

**Encrypting a Column**

```sql
-- Open the symmetric key
OPEN SYMMETRIC KEY MySymmetricKey
DECRYPTION BY CERTIFICATE MyCertificate;

-- Encrypt data
UPDATE Employees
SET EncryptedSalary = ENCRYPTBYKEY(KEY_GUID('MySymmetricKey'), CAST(Salary AS NVARCHAR(50)));

-- Close the symmetric key
CLOSE SYMMETRIC KEY MySymmetricKey;
```

**Decrypting a Column**

```sql
-- Open the symmetric key
OPEN SYMMETRIC KEY MySymmetricKey
DECRYPTION BY CERTIFICATE MyCertificate;

-- Decrypt data
SELECT
    EmployeeID,
    Name,
    CAST(DECRYPTBYKEY(EncryptedSalary) AS NVARCHAR(50)) AS DecryptedSalary
FROM Employees;

-- Close the symmetric key
CLOSE SYMMETRIC KEY MySymmetricKey;
```

### **28. Row-Level Security**

**Creating a Security Policy**

```sql
-- Create a predicate function
CREATE FUNCTION dbo.fn_securitypredicate(@DepartmentID INT)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN SELECT 1 AS fn_securitypredicate_result
WHERE @DepartmentID = 1; -- Only allow access to DepartmentID = 1

-- Create a security policy
CREATE SECURITY POLICY EmployeeSecurityPolicy
ADD FILTER PREDICATE dbo.fn_securitypredicate(DepartmentID)
ON dbo.Employees
WITH (STATE = ON);
```

### **29. Temporal Tables**

**Creating a Temporal Table**

```sql
CREATE TABLE EmployeesHistory (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Salary DECIMAL(10, 2),
    DepartmentID INT,
    ValidFrom DATETIME2 GENERATED ALWAYS AS ROW START,
    ValidTo DATETIME2 GENERATED ALWAYS AS ROW END,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeesHistoryArchive));
```

**Querying a Temporal Table**

```sql
-- Query current data
SELECT * FROM EmployeesHistory;

-- Query historical data
SELECT * FROM EmployeesHistory FOR SYSTEM_TIME ALL;
```

### **30. JSON Data Handling (Advanced)**

**Updating JSON Data**

```sql
DECLARE @json NVARCHAR(MAX) = N'[
    {"EmployeeID": 1, "Name": "John Doe", "Salary": 60000},
    {"EmployeeID": 2, "Name": "Jane Smith", "Salary": 70000}
]';

-- Update JSON data
SET @json = JSON_MODIFY(@json, '$[0].Salary', 65000);

-- Select updated JSON data
SELECT @json;
```

### **31. XML Data Handling (Advanced)**

**Updating XML Data**

```sql
DECLARE @xml XML = '<Employees>
    <Employee>
        <EmployeeID>1</EmployeeID>
        <Name>John Doe</Name>
        <Salary>60000</Salary>
    </Employee>
    <Employee>
        <EmployeeID>2</EmployeeID>
        <Name>Jane Smith</Name>
        <Salary>70000</Salary>
    </Employee>
</Employees>';

-- Update XML data
SET @xml.modify('replace value of (/Employees/Employee[EmployeeID=1]/Salary/text())[1] with 65000');

-- Select updated XML data
SELECT @xml;
```

### **32. Common Table Expressions (CTEs) (Advanced)**

**Multiple CTEs**

```sql
WITH DepartmentCTE AS (
    SELECT DepartmentID, DepartmentName
    FROM Departments
),
EmployeeCTE AS (
    SELECT EmployeeID, Name, DepartmentID
    FROM Employees
)
SELECT e.EmployeeID, e.Name, d.DepartmentName
FROM EmployeeCTE e
JOIN DepartmentCTE d ON e.DepartmentID = d.DepartmentID;
```

### **33. Window Functions (Advanced)**

**PERCENT_RANK**

```sql
SELECT
    EmployeeID,
    Name,
    Salary,
    PERCENT_RANK() OVER (ORDER BY Salary) AS PercentRank
FROM Employees;
```

**CUME_DIST**

```sql
SELECT
    EmployeeID,
    Name,
    Salary,
    CUME_DIST() OVER (ORDER BY Salary) AS CumulativeDistribution
FROM Employees;
```

### **34. Hierarchical Data**

**Using HierarchyID**

```sql
CREATE TABLE OrgChart (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Position NVARCHAR(50),
    OrgNode HIERARCHYID
);

-- Insert data
INSERT INTO OrgChart (EmployeeID, Name, Position, OrgNode)
VALUES (1, 'CEO', 'CEO', HIERARCHYID::GetRoot());

-- Insert data for subordinates
INSERT INTO OrgChart (EmployeeID, Name, Position, OrgNode)
VALUES (2, 'VP of Sales', 'VP', HIERARCHYID::GetRoot().GetDescendant(NULL, NULL));

INSERT INTO OrgChart (EmployeeID, Name, Position, OrgNode)
VALUES (3, 'VP of Marketing', 'VP', HIERARCHYID::GetRoot().GetDescendant(NULL, NULL));

-- Insert data for subordinates of VP of Sales
DECLARE @parent HIERARCHYID;
SELECT @parent = OrgNode FROM OrgChart WHERE EmployeeID = 2;

INSERT INTO OrgChart (EmployeeID, Name, Position, OrgNode)
VALUES (4, 'Sales Manager', 'Manager', @parent.GetDescendant(NULL, NULL));

-- Query hierarchical data
SELECT
    EmployeeID,
    Name,
    Position,
    OrgNode.ToString() AS OrgNode
FROM OrgChart
ORDER BY OrgNode;
```

### **35. Dynamic SQL**

**Using EXEC**

```sql
DECLARE @sql NVARCHAR(MAX);
SET @sql = 'SELECT * FROM Employees WHERE DepartmentID = 1';
EXEC(@sql);
```

**Using sp_executesql**

```sql
DECLARE @sql NVARCHAR(MAX);
DECLARE @departmentID INT = 1;

SET @sql = N'SELECT * FROM Employees WHERE DepartmentID = @deptID';
EXEC sp_executesql @sql, N'@deptID INT', @deptID = @departmentID;
```

### **36. Indexing (Advanced)**

**Filtered Index**

```sql
CREATE INDEX IX_Employees_Salary
ON Employees (Salary)
WHERE DepartmentID = 1;
```

**Covering Index**

```sql
CREATE INDEX IX_Employees_Covering
ON Employees (DepartmentID)
INCLUDE (Name, Salary);
```

### **37. Views (Advanced)**

**Indexed View**

```sql
CREATE VIEW vw_EmployeeSalary
WITH SCHEMABINDING
AS
SELECT
    DepartmentID,
    COUNT_BIG(*) AS EmployeeCount,
    AVG(Salary) AS AvgSalary
FROM dbo.Employees
GROUP BY DepartmentID;

-- Create a unique clustered index on the view
CREATE UNIQUE CLUSTERED INDEX IX_vw_EmployeeSalary
ON vw_EmployeeSalary (DepartmentID);
```

### **38. Stored Procedures (Advanced)**

**Stored Procedure with Output Parameters**

```sql
CREATE PROCEDURE GetEmployeeDetails
    @EmployeeID INT,
    @Name NVARCHAR(50) OUTPUT,
    @Salary DECIMAL(10, 2) OUTPUT
AS
BEGIN
    SELECT @Name = Name, @Salary = Salary
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;

-- Execute the stored procedure
DECLARE @Name NVARCHAR(50), @Salary DECIMAL(10, 2);
EXEC GetEmployeeDetails @EmployeeID = 1, @Name = @Name OUTPUT, @Salary = @Salary OUTPUT;
SELECT @Name AS Name, @Salary AS Salary;
```

### **39. Transactions (Advanced)**

**Savepoints**

```sql
BEGIN TRANSACTION;

-- First operation
UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentID = 1;

SAVE TRANSACTION SavePoint1;

-- Second operation
UPDATE Employees
SET Salary = Salary * 1.05
WHERE DepartmentID = 2;

-- Rollback to savepoint
ROLLBACK TRANSACTION SavePoint1;

-- Commit the transaction
COMMIT;
```

### **40. Performance Tuning**

**Query Execution Plan**

```sql
-- Display the estimated execution plan
SET SHOWPLAN_XML ON;
GO
SELECT * FROM Employees WHERE DepartmentID = 1;
GO
SET SHOWPLAN_XML OFF;
```

**Query Hints**

```sql
SELECT *
FROM Employees
WITH (NOLOCK)
WHERE DepartmentID = 1;
```

### **41. Data Compression**

**Row Compression**

```sql
ALTER TABLE Employees
REBUILD PARTITION = ALL
WITH (DATA_COMPRESSION = ROW);
```

**Page Compression**

```sql
ALTER TABLE Employees
REBUILD PARTITION = ALL
WITH (DATA_COMPRESSION = PAGE);
```

### **42. Data Masking**

**Dynamic Data Masking**

```sql
ALTER TABLE Employees
ALTER COLUMN Salary ADD MASKED WITH (FUNCTION = 'default()');

-- Query the masked data
SELECT EmployeeID, Name, Salary FROM Employees;
```

---

---

## SQL query by Category and topic

### **Basic SQL Queries**

1. **Question:** Retrieve all columns from the `Employees` table.

   ```sql
   SELECT * FROM Employees;
   ```

2. **Question:** Retrieve the `Name` and `Salary` columns from the `Employees` table.

   ```sql
   SELECT Name, Salary FROM Employees;
   ```

3. **Question:** Retrieve distinct `DepartmentID` values from the `Employees` table.

   ```sql
   SELECT DISTINCT DepartmentID FROM Employees;
   ```

4. **Question:** Retrieve all employees whose `Salary` is greater than 50000.

   ```sql
   SELECT * FROM Employees WHERE Salary > 50000;
   ```

5. **Question:** Retrieve all employees whose `Name` starts with 'A'.

   ```sql
   SELECT * FROM Employees WHERE Name LIKE 'A%';
   ```

6. **Question:** Retrieve all employees sorted by `Salary` in descending order.

   ```sql
   SELECT * FROM Employees ORDER BY Salary DESC;
   ```

7. **Question:** Retrieve the top 5 highest-paid employees.

   ```sql
   SELECT TOP 5 * FROM Employees ORDER BY Salary DESC;
   ```

8. **Question:** Retrieve employees who are in the `Sales` department.

   ```sql
   SELECT * FROM Employees WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Sales');
   ```

9. **Question:** Retrieve employees who were hired in the year 2020.

   ```sql
   SELECT * FROM Employees WHERE YEAR(HireDate) = 2020;
   ```

10. **Question:** Retrieve employees whose `Salary` is between 40000 and 60000.
    ```sql
    SELECT * FROM Employees WHERE Salary BETWEEN 40000 AND 60000;
    ```

### **Aggregate Functions**

1. **Question:** Find the total number of employees.

   ```sql
   SELECT COUNT(*) AS TotalEmployees FROM Employees;
   ```

2. **Question:** Find the average salary of employees.

   ```sql
   SELECT AVG(Salary) AS AverageSalary FROM Employees;
   ```

3. **Question:** Find the maximum salary in the `Employees` table.

   ```sql
   SELECT MAX(Salary) AS MaxSalary FROM Employees;
   ```

4. **Question:** Find the minimum salary in the `Employees` table.

   ```sql
   SELECT MIN(Salary) AS MinSalary FROM Employees;
   ```

5. **Question:** Find the total salary expenditure.

   ```sql
   SELECT SUM(Salary) AS TotalSalary FROM Employees;
   ```

6. **Question:** Find the number of employees in each department.

   ```sql
   SELECT DepartmentID, COUNT(*) AS EmployeeCount FROM Employees GROUP BY DepartmentID;
   ```

7. **Question:** Find the average salary in each department.

   ```sql
   SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM Employees GROUP BY DepartmentID;
   ```

8. **Question:** Find the highest salary in each department.

   ```sql
   SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees GROUP BY DepartmentID;
   ```

9. **Question:** Find the total number of employees hired each year.

   ```sql
   SELECT YEAR(HireDate) AS HireYear, COUNT(*) AS EmployeeCount FROM Employees GROUP BY YEAR(HireDate);
   ```

10. **Question:** Find the total salary expenditure for each department.
    ```sql
    SELECT DepartmentID, SUM(Salary) AS TotalSalary FROM Employees GROUP BY DepartmentID;
    ```

### **Joins**

1. **Question:** Retrieve all employees along with their department names.

   ```sql
   SELECT e.*, d.DepartmentName
   FROM Employees e
   JOIN Departments d ON e.DepartmentID = d.DepartmentID;
   ```

2. **Question:** Retrieve all employees and their managers.

   ```sql
   SELECT e.Name AS EmployeeName, m.Name AS ManagerName
   FROM Employees e
   LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID;
   ```

3. **Question:** Retrieve all departments and the number of employees in each department.

   ```sql
   SELECT d.DepartmentName, COUNT(e.EmployeeID) AS EmployeeCount
   FROM Departments d
   LEFT JOIN Employees e ON d.DepartmentID = e.DepartmentID
   GROUP BY d.DepartmentName;
   ```

4. **Question:** Retrieve all employees who have not been assigned to any department.

   ```sql
   SELECT e.*
   FROM Employees e
   LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
   WHERE d.DepartmentID IS NULL;
   ```

5. **Question:** Retrieve all employees along with their project names.

   ```sql
   SELECT e.Name AS EmployeeName, p.ProjectName
   FROM Employees e
   JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   JOIN Projects p ON ep.ProjectID = p.ProjectID;
   ```

6. **Question:** Retrieve all employees who are working on more than one project.

   ```sql
   SELECT e.Name, COUNT(ep.ProjectID) AS ProjectCount
   FROM Employees e
   JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   GROUP BY e.Name
   HAVING COUNT(ep.ProjectID) > 1;
   ```

7. **Question:** Retrieve all projects and the number of employees working on each project.

   ```sql
   SELECT p.ProjectName, COUNT(ep.EmployeeID) AS EmployeeCount
   FROM Projects p
   LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
   GROUP BY p.ProjectName;
   ```

8. **Question:** Retrieve all employees and their respective department names, including those without a department.

   ```sql
   SELECT e.Name AS EmployeeName, d.DepartmentName
   FROM Employees e
   LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID;
   ```

9. **Question:** Retrieve all departments and their managers.

   ```sql
   SELECT d.DepartmentName, m.Name AS ManagerName
   FROM Departments d
   JOIN Employees m ON d.ManagerID = m.EmployeeID;
   ```

10. **Question:** Retrieve all employees who are working on projects managed by a specific manager.
    ```sql
    SELECT e.Name AS EmployeeName, p.ProjectName
    FROM Employees e
    JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
    JOIN Projects p ON ep.ProjectID = p.ProjectID
    JOIN Employees m ON p.ManagerID = m.EmployeeID
    WHERE m.Name = 'Specific Manager Name';
    ```

### **Subqueries**

1. **Question:** Retrieve employees who earn more than the average salary.

   ```sql
   SELECT * FROM Employees
   WHERE Salary > (SELECT AVG(Salary) FROM Employees);
   ```

2. **Question:** Retrieve employees who work in the same department as 'John Doe'.

   ```sql
   SELECT * FROM Employees
   WHERE DepartmentID = (SELECT DepartmentID FROM Employees WHERE Name = 'John Doe');
   ```

3. **Question:** Retrieve the names of employees who work on the 'Project X'.

   ```sql
   SELECT Name FROM Employees
   WHERE EmployeeID IN (SELECT EmployeeID FROM EmployeeProjects WHERE ProjectID = (SELECT ProjectID FROM Projects WHERE ProjectName = 'Project X'));
   ```

4. **Question:** Retrieve departments that have more than 10 employees.

   ```sql
   SELECT DepartmentName FROM Departments
   WHERE DepartmentID IN (SELECT DepartmentID FROM Employees GROUP BY DepartmentID HAVING COUNT(*) > 10);
   ```

5. **Question:** Retrieve employees who have the highest salary in their department.

   ```sql
   SELECT * FROM Employees e
   WHERE Salary = (SELECT MAX(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID);
   ```

6. **Question:** Retrieve the names of employees who do not work on any project.

   ```sql
   SELECT Name FROM Employees
   WHERE EmployeeID NOT IN (SELECT EmployeeID FROM EmployeeProjects);
   ```

7. **Question:** Retrieve the departments where the average salary is higher than 60000.

   ```sql
   SELECT DepartmentName FROM Departments
   WHERE DepartmentID IN (SELECT DepartmentID FROM Employees GROUP BY DepartmentID HAVING AVG(Salary) > 60000);
   ```

8. **Question:** Retrieve the names of employees who joined the company before the average hire date.

   ```sql
   SELECT Name FROM Employees
   WHERE HireDate < (SELECT AVG(HireDate) FROM Employees);
   ```

9. **Question:** Retrieve the names of employees who have the same salary as 'Jane Doe'.

   ```sql
   SELECT Name FROM Employees
   WHERE Salary = (SELECT Salary FROM Employees WHERE Name = 'Jane Doe');
   ```

10. **Question:** Retrieve the names of employees who work in departments managed by 'Manager X'.
    ```sql
    SELECT Name FROM Employees
    WHERE DepartmentID IN (SELECT DepartmentID FROM Departments WHERE ManagerID = (SELECT EmployeeID FROM Employees WHERE Name = 'Manager X'));
    ```

### **Common Table Expressions (CTEs)**

1. **Question:** Retrieve the total number of employees in each department using a CTE.

   ```sql
   WITH DepartmentEmployeeCount AS (
       SELECT DepartmentID, COUNT(*) AS EmployeeCount
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT d.DepartmentName, dec.EmployeeCount
   FROM Departments d
   JOIN DepartmentEmployeeCount dec ON d.DepartmentID = dec.DepartmentID;
   ```

2. **Question:** Retrieve the average salary of employees in each department using a CTE.

   ```sql
   WITH DepartmentAverageSalary AS (
       SELECT DepartmentID, AVG(Salary) AS AverageSalary
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT d.DepartmentName, das.AverageSalary
   FROM Departments d
   JOIN DepartmentAverageSalary das ON d.DepartmentID = das.DepartmentID;
   ```

3. **Question:** Retrieve the names of employees who earn more than the average salary of their department using a CTE.

   ```sql
   WITH DepartmentAverageSalary AS (
       SELECT DepartmentID, AVG(Salary) AS AverageSalary
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT e.Name, e.Salary, das.AverageSalary
   FROM Employees e
   JOIN DepartmentAverageSalary das ON e.DepartmentID = das.DepartmentID
   WHERE e.Salary > das.AverageSalary;
   ```

4. **Question:** Retrieve the hierarchy of employees and their managers using a recursive CTE.

   ```sql
   WITH EmployeeHierarchy AS (
       SELECT EmployeeID, Name, ManagerID, 0 AS Level
       FROM Employees
       WHERE ManagerID IS NULL
       UNION ALL
       SELECT e.EmployeeID, e.Name, e.ManagerID, eh.Level + 1
       FROM Employees e
       JOIN EmployeeHierarchy eh ON e.ManagerID = eh.EmployeeID
   )
   SELECT * FROM EmployeeHierarchy
   ORDER BY Level, ManagerID;
   ```

5. **Question:** Retrieve the cumulative salary expenditure for each department using a CTE.

   ```sql
   WITH DepartmentSalaryExpenditure AS (
       SELECT DepartmentID, SUM(Salary) AS TotalSalary
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT d.DepartmentName, dse.TotalSalary
   FROM Departments d
   JOIN DepartmentSalaryExpenditure dse ON d.DepartmentID = dse.DepartmentID;
   ```

6. **Question:** Retrieve the top 3 highest-paid employees in each department using a CTE.

   ```sql
   WITH RankedSalaries AS (
       SELECT EmployeeID, Name, DepartmentID, Salary,
              ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
       FROM Employees
   )
   SELECT * FROM RankedSalaries
   WHERE Rank <= 3;
   ```

7. **Question:** Retrieve the total number of projects each employee is working on using a CTE.

   ```sql
   WITH EmployeeProjectCount AS (
       SELECT EmployeeID, COUNT(ProjectID) AS ProjectCount
       FROM EmployeeProjects
       GROUP BY EmployeeID
   )
   SELECT e.Name, epc.ProjectCount
   FROM Employees e
   JOIN EmployeeProjectCount epc ON e.EmployeeID = epc.EmployeeID;
   ```

8. **Question:** Retrieve the names of employees who have worked on more than 2 projects using a CTE.

   ```sql
   WITH EmployeeProjectCount AS (
       SELECT EmployeeID, COUNT(ProjectID) AS ProjectCount
       FROM EmployeeProjects
       GROUP BY EmployeeID
   )
   SELECT e.Name
   FROM Employees e
   JOIN EmployeeProjectCount epc ON e.EmployeeID = epc.EmployeeID
   WHERE epc.ProjectCount > 2;
   ```

9. **Question:** Retrieve the total number of employees hired each year using a CTE.

   ```sql
   WITH YearlyHires AS (
       SELECT YEAR(HireDate) AS HireYear, COUNT(*) AS EmployeeCount
       FROM Employees
       GROUP BY YEAR(HireDate)
   )
   SELECT * FROM YearlyHires
   ORDER BY HireYear;
   ```

10. **Question:** Retrieve the names of employees who have the same salary as the highest-paid employee in their department using a CTE.
    ```sql
    WITH DepartmentMaxSalary AS (
        SELECT DepartmentID, MAX(Salary) AS MaxSalary
        FROM Employees
        GROUP BY DepartmentID
    )
    SELECT e.Name, e.Salary
    FROM Employees e
    JOIN DepartmentMaxSalary dms ON e.DepartmentID = dms.DepartmentID
    WHERE e.Salary = dms.MaxSalary;
    ```

### **Window Functions**

1. **Question:** Retrieve the cumulative salary of employees ordered by their hire date.

   ```sql
   SELECT Name, HireDate, Salary,
          SUM(Salary) OVER (ORDER BY HireDate) AS CumulativeSalary
   FROM Employees
   ORDER BY HireDate;
   ```

2. **Question:** Retrieve the rank of employees based on their salary within each department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
   FROM Employees;
   ```

3. **Question:** Retrieve the average salary of employees within each department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          AVG(Salary) OVER (PARTITION BY DepartmentID) AS AvgDepartmentSalary
   FROM Employees;
   ```

4. **Question:** Retrieve the difference between each employee's salary and the average salary of their department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          Salary - AVG(Salary) OVER (PARTITION BY DepartmentID) AS SalaryDifference
   FROM Employees;
   ```

5. **Question:** Retrieve the top 3 highest-paid employees in each department.

   ```sql
   SELECT Name, DepartmentID, Salary
   FROM (
       SELECT Name, DepartmentID, Salary,
              ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RowNum
       FROM Employees
   ) AS RankedEmployees
   WHERE RowNum <= 3;
   ```

6. **Question:** Retrieve the running total of salaries for each department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS RunningTotal
   FROM Employees;
   ```

7. **Question:** Retrieve the percentage of total salary each employee's salary represents within their department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          Salary * 1.0 / SUM(Salary) OVER (PARTITION BY DepartmentID) AS SalaryPercentage
   FROM Employees;
   ```

8. **Question:** Retrieve the lag (previous) and lead (next) salary for each employee within their department.

   ```sql
   SELECT Name, DepartmentID, Salary,
          LAG(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS PreviousSalary,
          LEAD(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS NextSalary
   FROM Employees;
   ```

9. **Question:** Retrieve the first and last hire date within each department.

   ```sql
   SELECT DepartmentID,
          FIRST_VALUE(HireDate) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS FirstHireDate,
          LAST_VALUE(HireDate) OVER (PARTITION BY DepartmentID ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS LastHireDate
   FROM Employees;
   ```

10. **Question:** Retrieve the Nth highest salary in each department (e.g., 3rd highest).

    ```sql
    WITH RankedSalaries AS (
        SELECT Name, DepartmentID, Salary,
               DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
        FROM Employees
    )
    SELECT Name, DepartmentID, Salary
    FROM RankedSalaries
    WHERE SalaryRank = 3;
    ```

11. **Question:** Retrieve the moving average of salaries over the last 3 employees ordered by hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           AVG(Salary) OVER (ORDER BY HireDate ROWS BETWEEN 2 PRECEDING AND CURRENT ROW) AS MovingAverage
    FROM Employees;
    ```

12. **Question:** Retrieve the cumulative count of employees within each department.

    ```sql
    SELECT Name, DepartmentID,
           COUNT(*) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeCount
    FROM Employees;
    ```

13. **Question:** Retrieve the median salary within each department.

    ```sql
    SELECT DepartmentID,
           PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary) OVER (PARTITION BY DepartmentID) AS MedianSalary
    FROM Employees;
    ```

14. **Question:** Retrieve the cumulative percentage of total salary for each employee within their department.

    ```sql
    SELECT Name, DepartmentID, Salary,
           SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) * 1.0 / SUM(Salary) OVER (PARTITION BY DepartmentID) AS CumulativePercentage
    FROM Employees;
    ```

15. **Question:** Retrieve the difference between each employee's salary and the previous employee's salary within their department.

    ```sql
    SELECT Name, DepartmentID, Salary,
           Salary - LAG(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS SalaryDifference
    FROM Employees;
    ```

16. **Question:** Retrieve the cumulative sum of salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           SUM(Salary) OVER (ORDER BY HireDate) AS CumulativeSalary
    FROM Employees;
    ```

17. **Question:** Retrieve the rank of employees based on their hire date within each department.

    ```sql
    SELECT Name, DepartmentID, HireDate,
           RANK() OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS HireDateRank
    FROM Employees;
    ```

18. **Question:** Retrieve the dense rank of employees based on their salary within each department.

    ```sql
    SELECT Name, DepartmentID, Salary,
           DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryDenseRank
    FROM Employees;
    ```

19. **Question:** Retrieve the Nth highest salary in the entire company (e.g., 5th highest).

    ```sql
    WITH RankedSalaries AS (
        SELECT Name, Salary,
               DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
        FROM Employees
    )
    SELECT Name, Salary
    FROM RankedSalaries
    WHERE SalaryRank = 5;
    ```

20. **Question:** Retrieve the cumulative average salary for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           AVG(Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeAverage
    FROM Employees;
    ```

21. **Question:** Retrieve the first and last salary within each department.

    ```sql
    SELECT DepartmentID,
           FIRST_VALUE(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS FirstSalary,
           LAST_VALUE(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS LastSalary
    FROM Employees;
    ```

22. **Question:** Retrieve the cumulative count of employees ordered by their hire date.

    ```sql
    SELECT Name, HireDate,
           COUNT(*) OVER (ORDER BY HireDate) AS CumulativeCount
    FROM Employees;
    ```

23. **Question:** Retrieve the cumulative maximum salary for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           MAX(Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeMaxSalary
    FROM Employees;
    ```

24. **Question:** Retrieve the cumulative minimum salary for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           MIN(Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeMinSalary
    FROM Employees;
    ```

25. **Question:** Retrieve the cumulative standard deviation of salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           STDDEV_SAMP(Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeStdDev
    FROM Employees;
    ```

26. **Question:** Retrieve the cumulative variance of salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           VAR_SAMP(Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeVariance
    FROM Employees;
    ```

27. **Question:** Retrieve the cumulative median salary for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeMedian
    FROM Employees;
    ```

28. **Question:** Retrieve the cumulative mode salary for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           MODE() WITHIN GROUP (ORDER BY Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeMode
    FROM Employees;
    ```

29. **Question:** Retrieve the cumulative count of distinct salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           COUNT(DISTINCT Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeDistinctSalaryCount
    FROM Employees;
    ```

30. **Question:** Retrieve the cumulative sum of distinct salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           SUM(DISTINCT Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeDistinctSalarySum
    FROM Employees;
    ```

31. **Question:** Retrieve the cumulative average of distinct salaries for each employee ordered by their hire date.

    ```sql
    SELECT Name, HireDate, Salary,
           AVG(DISTINCT Salary) OVER (ORDER BY HireDate ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS CumulativeDistinctSalaryAvg
    FROM Employees;
    ```

32. **Question:** Retrieve the cumulative count of employees within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate,
           COUNT(*) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentCount
    FROM Employees;
    ```

33. **Question:** Retrieve the cumulative sum of salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentSalary
    FROM Employees;
    ```

34. **Question:** Retrieve the cumulative average of salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           AVG(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentAvgSalary
    FROM Employees;
    ```

35. **Question:** Retrieve the cumulative maximum salary within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           MAX(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentMaxSalary
    FROM Employees;
    ```

36. **Question:** Retrieve the cumulative minimum salary within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           MIN(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentMinSalary
    FROM Employees;
    ```

37. **Question:** Retrieve the cumulative standard deviation of salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           STDDEV_SAMP(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentStdDev
    FROM Employees;
    ```

38. **Question:** Retrieve the cumulative variance of salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           VAR_SAMP(Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentVariance
    FROM Employees;
    ```

39. **Question:** Retrieve the cumulative median salary within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentMedian
    FROM Employees;
    ```

40. **Question:** Retrieve the cumulative mode salary within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           MODE() WITHIN GROUP (ORDER BY Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentMode
    FROM Employees;
    ```

41. **Question:** Retrieve the cumulative count of distinct salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           COUNT(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentDistinctSalaryCount
    FROM Employees;
    ```

42. **Question:** Retrieve the cumulative sum of distinct salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           SUM(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentDistinctSalarySum
    FROM Employees;
    ```

43. **Question:** Retrieve the cumulative average of distinct salaries within each department ordered by their hire date.

    ```sql
    SELECT Name, DepartmentID, HireDate, Salary,
           AVG(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY HireDate) AS CumulativeDepartmentDistinctSalaryAvg
    FROM Employees;
    ```

44. **Question:** Retrieve the cumulative count of employees within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           COUNT(*) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentCountBySalary
    FROM Employees;
    ```

45. **Question:** Retrieve the cumulative sum of salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentSalaryBySalary
    FROM Employees;
    ```

46. **Question:** Retrieve the cumulative average of salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           AVG(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentAvgSalaryBySalary
    FROM Employees;
    ```

47. **Question:** Retrieve the cumulative maximum salary within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           MAX(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentMaxSalaryBySalary
    FROM Employees;
    ```

48. **Question:** Retrieve the cumulative minimum salary within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           MIN(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentMinSalaryBySalary
    FROM Employees;
    ```

49. **Question:** Retrieve the cumulative standard deviation of salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           STDDEV_SAMP(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentStdDevBySalary
    FROM Employees;
    ```

50. **Question:** Retrieve the cumulative variance of salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           VAR_SAMP(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentVarianceBySalary
    FROM Employees;
    ```

51. **Question:** Retrieve the cumulative median salary within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentMedianBySalary
    FROM Employees;
    ```

52. **Question:** Retrieve the cumulative mode salary within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           MODE() WITHIN GROUP (ORDER BY Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentModeBySalary
    FROM Employees;
    ```

53. **Question:** Retrieve the cumulative count of distinct salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           COUNT(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentDistinctSalaryCountBySalary
    FROM Employees;
    ```

54. **Question:** Retrieve the cumulative sum of distinct salaries within each department ordered by their salary.

    ```sql
    SELECT Name, DepartmentID, Salary,
           SUM(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentDistinctSalarySumBySalary
    FROM Employees;
    ```

55. **Question:** Retrieve the cumulative average of distinct salaries within each department ordered by their salary.
    ```sql
    SELECT Name, DepartmentID, Salary,
           AVG(DISTINCT Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDepartmentDistinctSalaryAvgBySalary
    FROM Employees;
    ```

---

---

## SQL query by difficulty and category

### **Aggregate Functions**

#### **Easy**

1. **Question:** Find the total number of employees in the company.

   - **Problem Description:** Count the total number of employees.
   - **Explanation:** Use the `COUNT` function to count the number of rows in the `Employees` table.

   ```sql
   SELECT COUNT(*) AS TotalEmployees
   FROM Employees;
   ```

2. **Question:** Find the average salary of employees.

   - **Problem Description:** Calculate the average salary of all employees.
   - **Explanation:** Use the `AVG` function to calculate the average salary.

   ```sql
   SELECT AVG(Salary) AS AverageSalary
   FROM Employees;
   ```

3. **Question:** Find the maximum salary in the company.

   - **Problem Description:** Determine the highest salary among all employees.
   - **Explanation:** Use the `MAX` function to find the highest salary.

   ```sql
   SELECT MAX(Salary) AS MaxSalary
   FROM Employees;
   ```

4. **Question:** Find the minimum salary in the company.

   - **Problem Description:** Determine the lowest salary among all employees.
   - **Explanation:** Use the `MIN` function to find the lowest salary.

   ```sql
   SELECT MIN(Salary) AS MinSalary
   FROM Employees;
   ```

5. **Question:** Find the total salary expenditure of the company.
   - **Problem Description:** Calculate the sum of all salaries.
   - **Explanation:** Use the `SUM` function to calculate the total salary expenditure.
   ```sql
   SELECT SUM(Salary) AS TotalSalaryExpenditure
   FROM Employees;
   ```

#### **Medium**

6. **Question:** Find the average salary for each department.

   - **Problem Description:** Calculate the average salary for employees in each department.
   - **Explanation:** Use the `AVG` function with a `GROUP BY` clause to group by department.

   ```sql
   SELECT DepartmentID, AVG(Salary) AS AverageSalary
   FROM Employees
   GROUP BY DepartmentID;
   ```

7. **Question:** Find the number of employees in each department.

   - **Problem Description:** Count the number of employees in each department.
   - **Explanation:** Use the `COUNT` function with a `GROUP BY` clause to group by department.

   ```sql
   SELECT DepartmentID, COUNT(*) AS NumberOfEmployees
   FROM Employees
   GROUP BY DepartmentID;
   ```

8. **Question:** Find the total salary expenditure for each department.

   - **Problem Description:** Calculate the sum of salaries for employees in each department.
   - **Explanation:** Use the `SUM` function with a `GROUP BY` clause to group by department.

   ```sql
   SELECT DepartmentID, SUM(Salary) AS TotalSalaryExpenditure
   FROM Employees
   GROUP BY DepartmentID;
   ```

9. **Question:** Find the highest salary in each department.

   - **Problem Description:** Determine the highest salary for employees in each department.
   - **Explanation:** Use the `MAX` function with a `GROUP BY` clause to group by department.

   ```sql
   SELECT DepartmentID, MAX(Salary) AS MaxSalary
   FROM Employees
   GROUP BY DepartmentID;
   ```

10. **Question:** Find the lowest salary in each department.
    - **Problem Description:** Determine the lowest salary for employees in each department.
    - **Explanation:** Use the `MIN` function with a `GROUP BY` clause to group by department.
    ```sql
    SELECT DepartmentID, MIN(Salary) AS MinSalary
    FROM Employees
    GROUP BY DepartmentID;
    ```

#### **Hard**

11. **Question:** Find the average salary of employees who have been with the company for more than 5 years.

    - **Problem Description:** Calculate the average salary for employees with more than 5 years of service.
    - **Explanation:** Use the `AVG` function with a `WHERE` clause to filter employees based on their hire date.

    ```sql
    SELECT AVG(Salary) AS AverageSalary
    FROM Employees
    WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 5;
    ```

12. **Question:** Find the department with the highest average salary.

    - **Problem Description:** Determine which department has the highest average salary.
    - **Explanation:** Use the `AVG` function with a `GROUP BY` clause and `ORDER BY` to sort by average salary.

    ```sql
    SELECT TOP 1 DepartmentID, AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
    ORDER BY AverageSalary DESC;
    ```

13. **Question:** Find the total number of employees who earn more than the average salary.

    - **Problem Description:** Count the number of employees whose salary is above the average salary.
    - **Explanation:** Use a subquery to calculate the average salary and then use the `COUNT` function to count employees earning more than that average.

    ```sql
    SELECT COUNT(*) AS EmployeesAboveAverageSalary
    FROM Employees
    WHERE Salary > (SELECT AVG(Salary) FROM Employees);
    ```

14. **Question:** Find the department with the highest total salary expenditure.

    - **Problem Description:** Determine which department has the highest total salary expenditure.
    - **Explanation:** Use the `SUM` function with a `GROUP BY` clause and `ORDER BY` to sort by total salary expenditure.

    ```sql
    SELECT TOP 1 DepartmentID, SUM(Salary) AS TotalSalaryExpenditure
    FROM Employees
    GROUP BY DepartmentID
    ORDER BY TotalSalaryExpenditure DESC;
    ```

15. **Question:** Find the average salary of employees in each department who have been with the company for more than 3 years.

    - **Problem Description:** Calculate the average salary for employees in each department with more than 3 years of service.
    - **Explanation:** Use the `AVG` function with a `GROUP BY` clause and a `WHERE` clause to filter employees based on their hire date.

    ```sql
    SELECT DepartmentID, AVG(Salary) AS AverageSalary
    FROM Employees
    WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 3
    GROUP BY DepartmentID;
    ```

16. **Question:** Find the top 3 highest salaries in the company.

    - **Problem Description:** Retrieve the top 3 highest salaries.
    - **Explanation:** Use the `TOP` clause with `ORDER BY` to sort salaries in descending order.

    ```sql
    SELECT TOP 3 Salary
    FROM Employees
    ORDER BY Salary DESC;
    ```

17. **Question:** Find the average salary of the top 10% highest-paid employees.

    - **Problem Description:** Calculate the average salary of the top 10% highest-paid employees.
    - **Explanation:** Use the `PERCENT_RANK` window function to identify the top 10% and then calculate the average salary.

    ```sql
    WITH RankedSalaries AS (
        SELECT Salary, PERCENT_RANK() OVER (ORDER BY Salary DESC) AS PercentRank
        FROM Employees
    )
    SELECT AVG(Salary) AS AverageTop10PercentSalary
    FROM RankedSalaries
    WHERE PercentRank <= 0.1;
    ```

18. **Question:** Find the median salary of employees.

    - **Problem Description:** Calculate the median salary of all employees.
    - **Explanation:** Use the `PERCENTILE_CONT` function to calculate the median salary.

    ```sql
    SELECT PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary) AS MedianSalary
    FROM Employees;
    ```

19. **Question:** Find the department with the lowest average salary.

    - **Problem Description:** Determine which department has the lowest average salary.
    - **Explanation:** Use the `AVG` function with a `GROUP BY` clause and `ORDER BY` to sort by average salary.

    ```sql
    SELECT TOP 1 DepartmentID, AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
    ORDER BY AverageSalary ASC;
    ```

20. **Question:** Find the total number of distinct job titles in the company.

    - **Problem Description:** Count the number of distinct job titles.
    - **Explanation:** Use the `COUNT` function with the `DISTINCT` keyword to count unique job titles.

    ```sql
    SELECT COUNT(DISTINCT JobTitle) AS DistinctJobTitles
    FROM Employees;
    ```

21. **Question:** Find the average salary of employees grouped by their job title.
    - **Problem Description:** Calculate the average salary for each job title.
    - **Explanation:** Use the `AVG` function with a `GROUP BY` clause to group by job title.
    ```sql
    SELECT JobTitle, AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY JobTitle;
    ```

### **Joins**

#### **Easy**

1. **Question:** Retrieve the names of employees along with their department names.

   - **Problem Description:** Join the `Employees` table with the `Departments` table to get the department names.
   - **Explanation:** Use an `INNER JOIN` to combine the `Employees` and `Departments` tables.

   ```sql
   SELECT e.EmployeeName, d.DepartmentName
   FROM Employees e
   INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
   ```

2. **Question:** Retrieve the names of employees along with their manager names.

   - **Problem Description:** Join the `Employees` table with itself to get the manager names.
   - **Explanation:** Use a self-join to combine the `Employees` table with itself.

   ```sql
   SELECT e.EmployeeName, m.EmployeeName AS ManagerName
   FROM Employees e
   LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID;
   ```

3. **Question:** Retrieve all employees and their respective projects.
   - **Problem Description:** Join the `Employees` table with the `Projects` table to get project details.
   - **Explanation:** Use an `INNER JOIN` to combine the `Employees` and `Projects` tables.
   ```sql
   SELECT e.EmployeeName, p.ProjectName
   FROM Employees e
   INNER JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   INNER JOIN Projects p ON ep.ProjectID = p.ProjectID;
   ```

#### **Medium**

4. **Question:** Retrieve the names of employees who have not been assigned to any project.

   - **Problem Description:** Find employees who are not associated with any project.
   - **Explanation:** Use a `LEFT JOIN` and filter for `NULL` values in the `Projects` table.

   ```sql
   SELECT e.EmployeeName
   FROM Employees e
   LEFT JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   WHERE ep.ProjectID IS NULL;
   ```

5. **Question:** Retrieve the total number of employees in each department.

   - **Problem Description:** Count the number of employees in each department.
   - **Explanation:** Use an `INNER JOIN` with a `GROUP BY` clause.

   ```sql
   SELECT d.DepartmentName, COUNT(e.EmployeeID) AS NumberOfEmployees
   FROM Departments d
   INNER JOIN Employees e ON d.DepartmentID = e.DepartmentID
   GROUP BY d.DepartmentName;
   ```

6. **Question:** Retrieve the names of employees along with the total number of projects they are working on.
   - **Problem Description:** Count the number of projects each employee is working on.
   - **Explanation:** Use an `INNER JOIN` with a `GROUP BY` clause.
   ```sql
   SELECT e.EmployeeName, COUNT(ep.ProjectID) AS NumberOfProjects
   FROM Employees e
   INNER JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   GROUP BY e.EmployeeName;
   ```

#### **Hard**

7. **Question:** Retrieve the names of employees who are working on all projects.

   - **Problem Description:** Find employees who are associated with every project.
   - **Explanation:** Use a subquery to count the total number of projects and then use a `HAVING` clause.

   ```sql
   SELECT e.EmployeeName
   FROM Employees e
   INNER JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   GROUP BY e.EmployeeName
   HAVING COUNT(DISTINCT ep.ProjectID) = (SELECT COUNT(*) FROM Projects);
   ```

8. **Question:** Retrieve the names of employees along with their department names and the names of their managers.

   - **Problem Description:** Join the `Employees` table with the `Departments` table and perform a self-join to get manager names.
   - **Explanation:** Use an `INNER JOIN` and a self-join.

   ```sql
   SELECT e.EmployeeName, d.DepartmentName, m.EmployeeName AS ManagerName
   FROM Employees e
   INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
   LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID;
   ```

9. **Question:** Retrieve the names of departments that have more than 5 employees.
   - **Problem Description:** Find departments with more than 5 employees.
   - **Explanation:** Use an `INNER JOIN` with a `GROUP BY` and `HAVING` clause.
   ```sql
   SELECT d.DepartmentName
   FROM Departments d
   INNER JOIN Employees e ON d.DepartmentID = e.DepartmentID
   GROUP BY d.DepartmentName
   HAVING COUNT(e.EmployeeID) > 5;
   ```

### **Subqueries**

#### **Easy**

1. **Question:** Retrieve the names of employees who earn more than the average salary.

   - **Problem Description:** Find employees whose salary is above the average salary.
   - **Explanation:** Use a subquery to calculate the average salary and then filter employees based on this value.

   ```sql
   SELECT EmployeeName
   FROM Employees
   WHERE Salary > (SELECT AVG(Salary) FROM Employees);
   ```

2. **Question:** Retrieve the names of employees who work in the same department as 'John Doe'.

   - **Problem Description:** Find employees who are in the same department as a specific employee.
   - **Explanation:** Use a subquery to find the department of 'John Doe' and then filter employees based on this department.

   ```sql
   SELECT EmployeeName
   FROM Employees
   WHERE DepartmentID = (SELECT DepartmentID FROM Employees WHERE EmployeeName = 'John Doe');
   ```

3. **Question:** Retrieve the names of employees who are not assigned to any project.
   - **Problem Description:** Find employees who are not associated with any project.
   - **Explanation:** Use a subquery with the `NOT IN` clause.
   ```sql
   SELECT EmployeeName
   FROM Employees
   WHERE EmployeeID NOT IN (SELECT EmployeeID FROM EmployeeProjects);
   ```

#### **Medium**

4. **Question:** Retrieve the names of employees who earn more than the average salary of their department.

   - **Problem Description:** Find employees whose salary is above the average salary of their respective department.
   - **Explanation:** Use a correlated subquery to calculate the average salary for each department.

   ```sql
   SELECT EmployeeName
   FROM Employees e
   WHERE Salary > (SELECT AVG(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID);
   ```

5. **Question:** Retrieve the names of employees who have the highest salary in their department.

   - **Problem Description:** Find employees who have the highest salary within their department.
   - **Explanation:** Use a correlated subquery to find the maximum salary for each department.

   ```sql
   SELECT EmployeeName
   FROM Employees e
   WHERE Salary = (SELECT MAX(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID);
   ```

6. **Question:** Retrieve the names of employees who work on the same projects as 'Jane Smith'.
   - **Problem Description:** Find employees who are working on the same projects as a specific employee.
   - **Explanation:** Use a subquery to find the project IDs for 'Jane Smith' and then filter employees based on these project IDs.
   ```sql
   SELECT DISTINCT e.EmployeeName
   FROM Employees e
   INNER JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   WHERE ep.ProjectID IN (SELECT ProjectID FROM EmployeeProjects WHERE EmployeeID = (SELECT EmployeeID FROM Employees WHERE EmployeeName = 'Jane Smith'));
   ```

#### **Hard**

7. **Question:** Retrieve the names of employees who have never worked on a project with 'John Doe'.

   - **Problem Description:** Find employees who have never been on the same project as a specific employee.
   - **Explanation:** Use a subquery with the `NOT EXISTS` clause.

   ```sql
   SELECT e.EmployeeName
   FROM Employees e
   WHERE NOT EXISTS (
       SELECT 1
       FROM EmployeeProjects ep1
       INNER JOIN EmployeeProjects ep2 ON ep1.ProjectID = ep2.ProjectID
       WHERE ep1.EmployeeID = e.EmployeeID AND ep2.EmployeeID = (SELECT EmployeeID FROM Employees WHERE EmployeeName = 'John Doe')
   );
   ```

8. **Question:** Retrieve the names of employees who have the second highest salary in their department.

   - **Problem Description:** Find employees who have the second highest salary within their department.
   - **Explanation:** Use a subquery with the `ROW_NUMBER` window function.

   ```sql
   WITH RankedSalaries AS (
       SELECT EmployeeName, DepartmentID, Salary,
              ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RowNum
       FROM Employees
   )
   SELECT EmployeeName
   FROM RankedSalaries
   WHERE RowNum = 2;
   ```

9. **Question:** Retrieve the names of departments that have more than the average number of employees.
   - **Problem Description:** Find departments with more employees than the average number of employees per department.
   - **Explanation:** Use a subquery to calculate the average number of employees per department and then filter departments based on this value.
   ```sql
   SELECT DepartmentName
   FROM Departments d
   WHERE (SELECT COUNT(*) FROM Employees e WHERE e.DepartmentID = d.DepartmentID) >
         (SELECT AVG(EmployeeCount)
          FROM (SELECT COUNT(*) AS EmployeeCount FROM Employees GROUP BY DepartmentID) AS DeptCounts);
   ```

### **Common Table Expressions (CTEs)**

#### **Easy**

1. **Question:** Retrieve the names of employees along with their department names using a CTE.

   - **Problem Description:** Use a CTE to join the `Employees` and `Departments` tables.
   - **Explanation:** Define a CTE to simplify the query.

   ```sql
   WITH EmployeeDepartment AS (
       SELECT e.EmployeeName, d.DepartmentName
       FROM Employees e
       INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
   )
   SELECT * FROM EmployeeDepartment;
   ```

2. **Question:** Retrieve the names of employees who earn more than the average salary using a CTE.

   - **Problem Description:** Use a CTE to calculate the average salary and filter employees based on this value.
   - **Explanation:** Define a CTE to calculate the average salary.

   ```sql
   WITH AvgSalary AS (
       SELECT AVG(Salary) AS AvgSal FROM Employees
   )
   SELECT EmployeeName
   FROM Employees
   WHERE Salary > (SELECT AvgSal FROM AvgSalary);
   ```

3. **Question:** Retrieve the total number of employees in each department using a CTE.
   - **Problem Description:** Use a CTE to count the number of employees in each department.
   - **Explanation:** Define a CTE to simplify the query.
   ```sql
   WITH DepartmentEmployeeCount AS (
       SELECT DepartmentID, COUNT(EmployeeID) AS NumberOfEmployees
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT d.DepartmentName, dec.NumberOfEmployees
   FROM Departments d
   INNER JOIN DepartmentEmployeeCount dec ON d.DepartmentID = dec.DepartmentID;
   ```

#### **Medium**

4. **Question:** Retrieve the names of employees who have the highest salary in their department using a CTE.

   - **Problem Description:** Use a CTE to find employees with the highest salary within their department.
   - **Explanation:** Define a CTE to simplify the query.

   ```sql
   WITH MaxSalaryPerDept AS (
       SELECT DepartmentID, MAX(Salary) AS MaxSalary
       FROM Employees
       GROUP BY DepartmentID
   )
   SELECT e.EmployeeName, e.Salary, d.DepartmentName
   FROM Employees e
   INNER JOIN MaxSalaryPerDept msd ON e.DepartmentID = msd.DepartmentID AND e.Salary = msd.MaxSalary
   INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
   ```

5. **Question:** Retrieve the names of employees who work on the same projects as 'Jane Smith' using a CTE.

   - **Problem Description:** Use a CTE to find employees working on the same projects as a specific employee.
   - **Explanation:** Define a CTE to simplify the query.

   ```sql
   WITH JaneProjects AS (
       SELECT ProjectID
       FROM EmployeeProjects
       WHERE EmployeeID = (SELECT EmployeeID FROM Employees WHERE EmployeeName = 'Jane Smith')
   )
   SELECT DISTINCT e.EmployeeName
   FROM Employees e
   INNER JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
   WHERE ep.ProjectID IN (SELECT ProjectID FROM JaneProjects);
   ```

6. **Question:** Retrieve the names of employees along with their manager names using a CTE.
   - **Problem Description:** Use a CTE to join the `Employees` table with itself to get manager names.
   - **Explanation:** Define a CTE to simplify the query.
   ```sql
   WITH EmployeeManager AS (
       SELECT e.EmployeeName, m.EmployeeName AS ManagerName
       FROM Employees e
       LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
   )
   SELECT * FROM EmployeeManager;
   ```

#### **Hard**

1. **Question:** Retrieve the names of employees who have the second highest salary in their department using a CTE.

   - **Problem Description:** Use a CTE to find employees with the second highest salary within their department.
   - **Explanation:** Define a CTE to rank employees by salary within their department.

   ```sql
   WITH RankedSalaries AS (
       SELECT EmployeeName, DepartmentID, Salary,
              ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RowNum
       FROM Employees
   )
   SELECT EmployeeName
   FROM RankedSalaries
   WHERE RowNum = 2;
   ```

2. **Question:** Retrieve the names of employees who have never worked on a project with 'John Doe' using a CTE.

   - **Problem Description:** Use a CTE to find employees who have never been on the same project as a specific employee.
   - **Explanation:** Define a CTE to simplify the query.

   ```sql
   WITH JohnDoeProjects AS (
       SELECT ProjectID
       FROM EmployeeProjects
       WHERE EmployeeID = (SELECT EmployeeID FROM Employees WHERE EmployeeName = 'John Doe')
   )
   SELECT e.EmployeeName
   FROM Employees e
   WHERE NOT EXISTS (
       SELECT 1
       FROM EmployeeProjects ep
       WHERE ep.EmployeeID = e.EmployeeID AND ep.ProjectID IN (SELECT ProjectID FROM JohnDoeProjects)
   );
   ```

3. **Question:** Retrieve the names of departments that have more than the average number of employees using a CTE.
   - **Problem Description:** Use a CTE to calculate the average number of employees per department and then filter departments based on this value.
   - **Explanation:** Define a CTE to simplify the query.
   ```sql
   WITH DepartmentCounts AS (
       SELECT DepartmentID, COUNT(*) AS EmployeeCount
       FROM Employees
       GROUP BY DepartmentID
   ),
   AvgEmployeeCount AS (
       SELECT AVG(EmployeeCount) AS AvgCount
       FROM DepartmentCounts
   )
   SELECT d.DepartmentName
   FROM Departments d
   INNER JOIN DepartmentCounts dc ON d.DepartmentID = dc.DepartmentID
   WHERE dc.EmployeeCount > (SELECT AvgCount FROM AvgEmployeeCount);
   ```

### **Window Functions**

#### **Easy**

1. **Question:** Retrieve the names of employees along with their rank based on salary within their department.

   - **Problem Description:** Use a window function to rank employees by salary within their department.
   - **Explanation:** Use the `RANK()` window function.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
   FROM Employees;
   ```

2. **Question:** Retrieve the cumulative salary of employees within each department.

   - **Problem Description:** Use a window function to calculate the cumulative salary within each department.
   - **Explanation:** Use the `SUM()` window function with `OVER` clause.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeSalary
   FROM Employees;
   ```

3. **Question:** Retrieve the average salary of employees within each department.
   - **Problem Description:** Use a window function to calculate the average salary within each department.
   - **Explanation:** Use the `AVG()` window function with `OVER` clause.
   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          AVG(Salary) OVER (PARTITION BY DepartmentID) AS AvgDepartmentSalary
   FROM Employees;
   ```

#### **Medium**

4. **Question:** Retrieve the names of employees along with their salary and the difference between their salary and the average salary of their department.

   - **Problem Description:** Use a window function to calculate the difference between an employee's salary and the average salary of their department.
   - **Explanation:** Use the `AVG()` window function with `OVER` clause.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          Salary - AVG(Salary) OVER (PARTITION BY DepartmentID) AS SalaryDifference
   FROM Employees;
   ```

5. **Question:** Retrieve the names of employees along with their salary and the running total of salaries within their department.

   - **Problem Description:** Use a window function to calculate the running total of salaries within each department.
   - **Explanation:** Use the `SUM()` window function with `OVER` clause.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS RunningTotal
   FROM Employees;
   ```

6. **Question:** Retrieve the names of employees along with their salary and the running total of salaries within their department.

   - **Problem Description:** Use a window function to calculate the running total of salaries within each department.
   - **Explanation:** Use the `SUM()` window function with `OVER` clause.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          SUM(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS RunningTotal
   FROM Employees;
   ```

7. **Question:** Retrieve the names of employees along with their salary and the percentage of the total salary within their department.

   - **Problem Description:** Use a window function to calculate the percentage of the total salary within each department.
   - **Explanation:** Use the `SUM()` window function with `OVER` clause to calculate the total salary and then compute the percentage.

   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          Salary * 1.0 / SUM(Salary) OVER (PARTITION BY DepartmentID) AS SalaryPercentage
   FROM Employees;
   ```

8. **Question:** Retrieve the names of employees along with their salary and the difference between their salary and the highest salary in their department.
   - **Problem Description:** Use a window function to calculate the difference between an employee's salary and the highest salary in their department.
   - **Explanation:** Use the `MAX()` window function with `OVER` clause.
   ```sql
   SELECT EmployeeName, DepartmentID, Salary,
          MAX(Salary) OVER (PARTITION BY DepartmentID) - Salary AS SalaryDifference
   FROM Employees;
   ```

#### **Hard**

9. **Question:** Retrieve the names of employees along with their salary and the rank of their salary within the entire company.

   - **Problem Description:** Use a window function to rank employees by salary within the entire company.
   - **Explanation:** Use the `RANK()` window function without partitioning.

   ```sql
   SELECT EmployeeName, Salary,
          RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
   FROM Employees;
   ```

10. **Question:** Retrieve the names of employees along with their salary and the rank of their salary within their department, but only show the top 3 salaries per department.

    - **Problem Description:** Use a window function to rank employees by salary within their department and filter to show only the top 3.
    - **Explanation:** Use the `RANK()` window function with `PARTITION BY` and a subquery to filter the results.

    ```sql
    WITH RankedSalaries AS (
        SELECT EmployeeName, DepartmentID, Salary,
               RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
        FROM Employees
    )
    SELECT EmployeeName, DepartmentID, Salary
    FROM RankedSalaries
    WHERE SalaryRank <= 3;
    ```

11. **Question:** Retrieve the names of employees along with their salary and the moving average of their salary within their department over the last 3 employees.

    - **Problem Description:** Use a window function to calculate the moving average of salaries within each department over the last 3 employees.
    - **Explanation:** Use the `AVG()` window function with `ROWS BETWEEN` clause.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           AVG(Salary) OVER (PARTITION BY DepartmentID ORDER BY Salary
                             ROWS BETWEEN 2 PRECEDING AND CURRENT ROW) AS MovingAvgSalary
    FROM Employees;
    ```

12. **Question:** Retrieve the names of employees along with their salary and the cumulative distribution of their salary within their department.

    - **Problem Description:** Use a window function to calculate the cumulative distribution of salaries within each department.
    - **Explanation:** Use the `CUME_DIST()` window function.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           CUME_DIST() OVER (PARTITION BY DepartmentID ORDER BY Salary) AS CumulativeDistribution
    FROM Employees;
    ```

13. **Question:** Retrieve the names of employees along with their salary and the nth value of salary within their department.

    - **Problem Description:** Use a window function to retrieve the nth value of salary within each department.
    - **Explanation:** Use the `NTH_VALUE()` window function.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           NTH_VALUE(Salary, 3) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS NthSalary
    FROM Employees;
    ```

14. **Question:** Retrieve the names of employees along with their salary and the lag of their salary within their department.

    - **Problem Description:** Use a window function to retrieve the lag of salary within each department.
    - **Explanation:** Use the `LAG()` window function.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           LAG(Salary, 1) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS PreviousSalary
    FROM Employees;
    ```

15. **Question:** Retrieve the names of employees along with their salary and the lead of their salary within their department.

    - **Problem Description:** Use a window function to retrieve the lead of salary within each department.
    - **Explanation:** Use the `LEAD()` window function.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           LEAD(Salary, 1) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS NextSalary
    FROM Employees;
    ```

16. **Question:** Retrieve the names of employees along with their salary and the difference between their salary and the previous salary within their department.

    - **Problem Description:** Use a window function to calculate the difference between an employee's salary and the previous salary within their department.
    - **Explanation:** Use the `LAG()` window function to get the previous salary and then compute the difference.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           Salary - LAG(Salary, 1) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS SalaryDifference
    FROM Employees;
    ```

17. **Question:** Retrieve the names of employees along with their salary and the rank of their salary within their department, but only show employees whose salary is above the average salary of their department.

    - **Problem Description:** Use a window function to rank employees by salary within their department and filter to show only those with above-average salaries.
    - **Explanation:** Use the `RANK()` and `AVG()` window functions.

    ```sql
    WITH RankedSalaries AS (
        SELECT EmployeeName, DepartmentID, Salary,
               RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank,
               AVG(Salary) OVER (PARTITION BY DepartmentID) AS AvgDepartmentSalary
        FROM Employees
    )
    SELECT EmployeeName, DepartmentID, Salary, SalaryRank
    FROM RankedSalaries
    WHERE Salary > AvgDepartmentSalary;
    ```

18. **Question:** Retrieve the names of employees along with their salary and the row number of their salary within their department, but only show the top 5 salaries per department.

    - **Problem Description:** Use a window function to assign row numbers to employees by salary within their department and filter to show only the top 5.
    - **Explanation:** Use the `ROW_NUMBER()` window function with `PARTITION BY` and a subquery to filter the results.

    ```sql
    WITH NumberedSalaries AS (
        SELECT EmployeeName, DepartmentID, Salary,
               ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RowNum
        FROM Employees
    )
    SELECT EmployeeName, DepartmentID, Salary
    FROM NumberedSalaries
    WHERE RowNum <= 5;
    ```

19. **Question:** Retrieve the names of employees along with their salary and the dense rank of their salary within their department.

    - **Problem Description:** Use a window function to assign dense ranks to employees by salary within their department.
    - **Explanation:** Use the `DENSE_RANK()` window function.

    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS DenseRank
    FROM Employees;
    ```

20. **Question:** Retrieve the names of employees along with their salary and the NTILE of their salary within their department, dividing the salaries into 4 quartiles.
    - **Problem Description:** Use a window function to divide the salaries within each department into 4 quartiles.
    - **Explanation:** Use the `NTILE()` window function.
    ```sql
    SELECT EmployeeName, DepartmentID, Salary,
           NTILE(4) OVER (PARTITION BY DepartmentID ORDER BY Salary) AS Quartile
    FROM Employees;
    ```
