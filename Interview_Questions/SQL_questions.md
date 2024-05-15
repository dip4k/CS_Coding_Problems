## SQL Interview Questions

### 1. Write SQL query to retrieve the names having more than 3 subjects in a table with (id, name, subject) columns.

**Approach 1:**

```sql
SELECT name
FROM students
GROUP BY name
HAVING COUNT(subject) > 3
```

**Approach 2:**

```sql
SELECT name
FROM (
    SELECT name, COUNT(subject) as subject_count
    FROM students
    GROUP BY name
) as student_subject_count
WHERE subject_count > 3
```

In both approaches, the query will return all the names of students who are studying more than 3 subjects. The GROUP BY clause groups the results by the student names, and the HAVING clause filters out the groups that have more than 3 subjects.

### 2. Write a SQL query to get the third highest salary from a table Employee.

**Approach 1:**

```sql
SELECT TOP 1 salary
FROM (
    SELECT DISTINCT TOP 3 salary
    FROM Employee
    ORDER BY salary DESC
) AS emp
ORDER BY salary
```

**Approach 2:**

```sql
SELECT salary
FROM Employee E1
WHERE 2 = (
    SELECT COUNT(DISTINCT salary)
    FROM Employee E2
    WHERE E2.salary > E1.salary
)
```

In the first approach, the query first selects the top 3 distinct salaries in descending order. The result is then used as a subquery to select the top salary in ascending order, which gives the third highest salary. In the second approach, the query uses a subquery to count the distinct salaries that are greater than the current salary. The main query then selects the salary where the count of greater salaries is 2, which is the third highest salary.

### 3. Write a SQL query to find employees who have the same salary.

**Approach 1:**

```sql
SELECT e1.name, e1.salary
FROM Employee e1
JOIN Employee e2
ON e1.salary = e2.salary
WHERE e1.id != e2.id
```

**Approach 2:**

```sql
SELECT name, salary
FROM Employee
WHERE salary IN (
    SELECT salary
    FROM Employee
    GROUP BY salary
    HAVING COUNT(id) > 1
)
```

In the first approach, the query joins the Employee table to itself on the salary field. The WHERE clause ensures that we don't count the same employee twice. In the second approach, the subquery first finds the salaries that appear more than once in the Employee table. The main query then selects the employees that have these salaries.

## SQL Interview Questions

### 1. Write SQL query to retrieve the names having more than 3 subjects in a table with (id, name, subject) columns.

#### Approach 1: Using GROUP BY and HAVING
```sql
SELECT name
FROM students
GROUP BY name
HAVING COUNT(subject) > 3
```
This query will return all the names of students who are studying more than 3 subjects. The GROUP BY clause groups the results by the student names, and the HAVING clause filters out the groups that have more than 3 subjects.

#### Approach 2: Using subquery
```sql
SELECT name
FROM students
WHERE name IN (
    SELECT name
    FROM students
    GROUP BY name
    HAVING COUNT(subject) > 3
)
```
In this query, the subquery returns the names of students who are studying more than 3 subjects. The main query then returns the names from the students table that are in this list.

### 3. Write a SQL query to get the third highest salary from a table Employee. 

#### Approach 1: Using TOP and subquery
```sql
SELECT TOP 1 salary
FROM (
    SELECT DISTINCT TOP 3 salary
    FROM Employee
    ORDER BY salary DESC
) AS emp
ORDER BY salary
```

This query first selects the top 3 distinct salaries in descending order. The result is then used as a subquery to select the top salary in ascending order, which gives the third highest salary.

#### Approach 2: Using LIMIT and OFFSET
```sql
SELECT salary
FROM Employee
ORDER BY salary DESC
LIMIT 1 OFFSET 2
```
This query orders the salaries in descending order, skips the first two salaries using the OFFSET clause, and then returns the next salary using the LIMIT clause, which gives the third highest salary.

### 7. Write a SQL query to find employees who have the same salary.

#### Approach 1: Using JOIN
```sql
SELECT e1.name, e1.salary
FROM Employee e1
JOIN Employee e2
ON e1.salary = e2.salary
WHERE e1.id != e2.id
```

This query joins the Employee table to itself on the salary field. The WHERE clause ensures that we don't count the same employee twice.

#### Approach 2: Using EXISTS
```sql
SELECT e1.name, e1.salary
FROM Employee e1
WHERE EXISTS (
    SELECT 1 FROM Employee e2
    WHERE e1.salary = e2.salary
    AND e1.id != e2.id
)
```

This query uses the EXISTS clause to check if there is another employee with the same salary. If such an employee exists, then the current employee is included in the result.

## SQL Interview Questions

### 1. Write SQL query to retrieve the names having more than 3 subjects in a table with (id, name, subject) columns.

**Approach 1:**

```sql
SELECT name
FROM students
GROUP BY name
HAVING COUNT(DISTINCT subject) > 3
```
**Approach 2:**

```sql
SELECT name
FROM (
    SELECT name, COUNT(DISTINCT subject) as subject_count
    FROM students
    GROUP BY name
) as student_counts
WHERE subject_count > 3
```

These queries will return all the names of students who are studying more than 3 subjects. The GROUP BY clause groups the results by the student names, and the HAVING clause filters out the groups that have more than 3 subjects.

### 2. Write a SQL query to get the third highest salary from a table Employee.

**Approach 1:**

```sql
SELECT TOP 1 salary
FROM (
    SELECT DISTINCT TOP 3 salary
    FROM Employee
    ORDER BY salary DESC
) AS emp
ORDER BY salary
```

**Approach 2:**

```sql
SELECT salary
FROM Employee e1
WHERE 2 = (
    SELECT COUNT(DISTINCT salary)
    FROM Employee e2
    WHERE e2.salary > e1.salary
)
```

These queries first select the top 3 distinct salaries in descending order. The result is then used as a subquery to select the top salary in ascending order, which gives the third highest salary.

### 3. Write a SQL query to find employees who have the same salary.

**Approach 1:**

```sql
SELECT e1.name, e1.salary
FROM Employee e1
JOIN Employee e2
ON e1.salary = e2.salary
WHERE e1.id != e2.id
```

**Approach 2:**

```sql
SELECT name, salary
FROM Employee
GROUP BY salary
HAVING COUNT(id) > 1
```

These queries join the Employee table to itself on the salary field. The WHERE clause ensures that we don't count the same employee twice.

### 4. Write a SQL query to fetch employee names having the second highest salary.

**Approach 1:**

```sql
SELECT MAX(salary), name
FROM Employee
WHERE salary < (SELECT MAX(salary) FROM Employee)
```

**Approach 2:**

```sql
SELECT salary, name
FROM Employee
WHERE salary = (SELECT salary FROM Employee ORDER BY salary DESC LIMIT 1 OFFSET 1)
```

### 5. What are SQL Injections and how can you prevent them?

SQL Injection is a code injection technique, used to attack data-driven applications, in which malicious SQL statements are inserted into an entry field for execution.

To prevent SQL injections:
- Use parameterized queries or prepared statements.
- Use stored procedures.
- Don't use dynamic SQL.
- Escape all user supplied input.
- Keep your database system and application up to date.

### 6. How can you optimize a SQL query?

There are several ways to optimize a SQL query:

- Use `EXPLAIN PLAN` to understand the query plan and optimize it.
- Avoid using `SELECT *` and select only the necessary columns.
- Use proper indexing to speed up the access of data from a database.
- Avoid using non-correlated scalar sub query.
- Use `LIMIT` to sample query results.
- Use `JOIN` instead of sub-queries if possible.

### 7. What is a SQL View and explain its use cases?

A SQL View is a virtual table, which is based on the result-set of an SQL statement. It contains rows and columns, just like a real table. The fields in a view are fields from one or more real tables in the database. 

Use cases:
- Views can be used to hide the complexity of data. For example, a view could be used to provide a user-friendly way of accessing a table that has been normalised to 3NF and therefore has a complex structure.
- Views can be used to encapsulate the name of the table. If the table name changes, only the view needs to be updated.
- Views can be used to expose only certain parts of the data to users for security reasons.

## SQL Interview Questions

### 1. How can you find duplicate records in a table?

**Approach 1:**

```sql
SELECT name, COUNT(name)
FROM Employee
GROUP BY name
HAVING COUNT(name) > 1
```

**Approach 2:**

```sql
SELECT e1.*
FROM Employee e1, Employee e2
WHERE e1.id > e2.id
AND e1.name = e2.name
```
These queries find the duplicate records in the `Employee` table. The first approach uses the `GROUP BY` clause to group the records by names and the `HAVING` clause to filter out names that appear more than once. The second approach uses a self join to compare each record with all others.

**Real life example:** This can be useful when you're dealing with large datasets and want to ensure data integrity by removing duplicates.

### 2. Write a SQL query to fetch intersecting records of two tables.

```sql
SELECT * 
FROM Employee1
INTERSECT
SELECT *
FROM Employee2
```
This query will return all the records that are common to both `Employee1` and `Employee2` tables. 

**Real life example:** This can be useful when you're trying to find common data between two different datasets, such as finding common customers between two different stores.

### 3. What is the difference between a Clustered and a Non-Clustered Index?

A clustered index determines the physical order of data in a table. There can only be one clustered index per table. Non-clustered index, on the other hand, does not alter the physical order of data and a table can have multiple non-clustered indexes.

**Real life example:** A phone book, where data is stored in order of last name, can be considered as an example of a clustered index. An index in the back of a book, where page numbers are associated with keywords, is an example of a non-clustered index.

### 4. How do you handle NULL values in SQL?

NULL values can be handled using IS NULL or IS NOT NULL in the WHERE clause to include or exclude the NULL values. We can also use COALESCE() function to handle NULL values. 

**Real life example:** If you're querying a database of customers and some customers don't have a phone number, you can use IS NULL to find customers without a phone number, or use COALESCE() to replace NULL phone numbers with a default value.

### 5. How to retrieve the only rows that are present in one dataset but not in another?

```sql
SELECT * 
FROM Employee1
EXCEPT
SELECT *
FROM Employee2
```
This query will return all the records that are present in `Employee1` table but not in `Employee2` table.

**Real life example:** This can be useful when you're trying to find data that's unique to one dataset, such as finding customers who have purchased in one store but not in another.

### 6. What are the ways to optimize SQL queries?

- Select only the necessary columns instead of using `SELECT *`.
- Use `LIMIT` to limit the number of results.
- Use `JOIN` instead of subqueries if possible.
- Use `EXPLAIN PLAN` to understand the query execution plan and optimize it.
- Use indexes to speed up data retrieval.
- Avoid using functions in the WHERE clause.

**Real life example:** If you're working with a large database and your SQL queries are running slowly, you can use these optimization techniques to speed up your queries. For example, if you're only interested in a customer's name and email, select only those columns instead of using `SELECT *`.

## SQL Interview Questions

### 1. How would you find the Nth highest salary from a table?

**Approach 1:**

```sql
SELECT salary
FROM Employee e1
WHERE N-1 = (
    SELECT COUNT(DISTINCT salary)
    FROM Employee e2
    WHERE e2.salary > e1.salary
)
```

**Approach 2:**

```sql
SELECT salary
FROM (
    SELECT DISTINCT salary
    FROM Employee
    ORDER BY salary DESC
    LIMIT N-1, 1
) AS emp
```

**Real life example:** These queries can be used in a payroll application where you want to find out the Nth highest salary among all employees.

### 2. What is a transaction and what are ACID properties?

A transaction is a single logical unit of work that accesses and possibly modifies the contents of a database. Transactions access data using read and write operations.

ACID properties are:

- **Atomicity**: This property ensures that all work unit are successfully completed.
- **Consistency**: This property ensures that the database properly changes states upon a successfully committed transaction.
- **Isolation**: This property enables transactions to operate independently of and transparent to each other.
- **Durability**: This property ensures that the result or effect of a committed transaction persists in case of a system failure.

**Real life example:** When you are transferring money from one account to another, it involves two steps: withdrawing money from one account and depositing it into another. These steps together form a transaction.

### 3. How would you update a column to make all its values uppercase?

```sql
UPDATE Employee
SET name = UPPER(name)
```

**Real life example:** This can be useful when you want to standardize the values in a column, such as making all employee names uppercase for consistency.

### 4. How would you delete duplicate rows in a table?

```sql
WITH duplicates AS (
    SELECT name, ROW_NUMBER() OVER(PARTITION BY name ORDER BY name) AS row_num
    FROM Employee
)
DELETE FROM duplicates WHERE row_num > 1
```

**Real life example:** This can be useful when you want to clean up your data by removing duplicate rows.

### 5. How would you calculate the running total in SQL?

```sql
SELECT order_date, amount, SUM(amount) OVER(ORDER BY order_date) as running_total
FROM Orders
```

**Real life example:** This can be useful when you're trying to find the running total of sales in a store.

### 6. What is a Stored Procedure and provide a use case?

A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again. They can be used to perform tasks that are performed repeatedly or regularly.

**Use case:** Suppose a business rule states that every time a product is sold, the quantity of the product in the inventory has to be reduced, and the total sales amount has to be increased. Instead of writing the SQL every time a sale happens, you can create a stored procedure that can be called to easily perform the task.

## SQL Interview Questions

### 1. How would you find the Nth highest record in a database column?

**Approach 1:**

```sql
SELECT name, salary
FROM Employee e1
WHERE N-1 = (
    SELECT COUNT(DISTINCT salary)
    FROM Employee e2
    WHERE e2.salary > e1.salary
)
```

**Approach 2:**

```sql
SELECT name, salary
FROM (
    SELECT name, salary, DENSE_RANK() OVER (ORDER BY salary DESC) as rank
    FROM Employee
) as Employee_ranks
WHERE rank = N
```

These queries return the employee with the Nth highest salary. The first approach uses a subquery to count the number of distinct salaries that are greater than the salary of each employee. The second approach uses the `DENSE_RANK` window function to assign a rank to each employee based on their salary.

**Real life example:** This can be useful when you're trying to find out who has the Nth highest salary in your company.

### 2. How would you update a column based on a condition?

```sql
UPDATE Employee
SET salary = salary * 1.1
WHERE performance_score > 8
```

This query increases the salary of employees who have a performance score greater than 8 by 10%.

**Real life example:** This can be used to give a raise to employees who have performed well.

### 3. How would you delete duplicate rows in a table?

```sql
DELETE FROM Employee
WHERE id NOT IN (
    SELECT MIN(id)
    FROM Employee
    GROUP BY name
)
```

This query deletes all rows from the `Employee` table where the `id` is not in the set of minimum `id`s for each group of rows with the same name.

**Real life example:** This can be used to clean up a table that has duplicate rows due to data entry errors.

### 4. How would you calculate the sum of a column based on a condition?

```sql
SELECT SUM(salary)
FROM Employee
WHERE department = 'Sales'
```

This query calculates the total salary of all employees in the Sales department.

**Real life example:** This can be used to calculate the total payroll of a department in your company.

### 5. How would you join two tables based on a common column?

```sql
SELECT e.name, d.department_name
FROM Employee e
JOIN Department d
ON e.department_id = d.id
```

This query joins the `Employee` and `Department` tables based on the `department_id` column, and selects the name of the employee and the name of their department.

**Real life example:** This can be used to generate a report of employees and their respective departments.

### 6. How would you optimize a slow running query?

- Use indexes on columns that are frequently queried.
- Avoid using functions in the WHERE clause.
- Limit the number of results using the `LIMIT` clause.
- Use `EXPLAIN PLAN` to understand the query execution plan.
- Use `JOIN` instead of subqueries if possible.

**Real life example:** If you're working with a large database and your SQL queries are running slowly, you can use these optimization techniques to speed up your queries. For example, if you frequently query employees by their last name, you might want to create an index on the `last_name` column.

## SQL Interview Questions

### 1. How would you write a SQL query to find the most frequent value in a column?

```sql
SELECT column_name, COUNT(column_name) as frequency
FROM table_name
GROUP BY column_name
ORDER BY frequency DESC
LIMIT 1
```

This query will return the most frequent value in the specified column.

**Real life example:** This can be useful in a scenario where you want to find out the most popular product in your e-commerce store, based on the `product_id` in the `orders` table.

### 2. How would you write a SQL query to fetch the details of employees who have a manager from a different department?

```sql
SELECT e.*
FROM Employee e
JOIN Employee m ON e.manager_id = m.id
WHERE e.department_id != m.department_id
```

This query will return the details of employees who have a manager from a different department.

**Real life example:** This can be useful in a scenario where you want to find out the employees who are managed cross-departmentally in your organization.

### 3. How would you write a SQL query to fetch the top 3 products sold in each category?

```sql
SELECT category, product, sales
FROM (
    SELECT category, product, sales,
           ROW_NUMBER() OVER (PARTITION BY category ORDER BY sales DESC) as rank
    FROM ProductSales
) tmp
WHERE rank <= 3
```

This query will return the top 3 products sold in each category.

**Real life example:** This can be useful in a scenario where you want to find out the best-selling products in each category in your e-commerce store.

### 4. How would you write a SQL query to calculate the running total of a numeric column?

```sql
SELECT date, sales, SUM(sales) OVER (ORDER BY date) as running_total
FROM Sales
```

This query will return the date, sales and running total of sales.

**Real life example:** This can be useful in a scenario where you want to track the running total of sales in your store.

### 5. How would you write a SQL query to fetch the employees who earn more than their manager?

```sql
SELECT e.*
FROM Employee e
JOIN Employee m ON e.manager_id = m.id
WHERE e.salary > m.salary
```

This query will return the details of employees who earn more than their manager.

**Real life example:** This can be useful in a scenario where you want to find out the employees who earn more than their manager in your organization.

## SQL Interview Questions

### 1. How would you write a query to get the running total of sales?

```sql
SELECT OrderDate, Amount, 
SUM(Amount) OVER (ORDER BY OrderDate ROWS UNBOUNDED PRECEDING) as RunningTotal
FROM SalesOrder
ORDER BY OrderDate
```

This query calculates the running total of sales using a window function.

**Use Case:** This can be used in a scenario where the finance department wants to track the running total of sales over time.

### 2. How would you write a query to get the percentage of each product's sales out of total sales?

```sql
SELECT ProductName, SUM(Amount) as ProductSales,
SUM(Amount) * 100.0 / SUM(SUM(Amount)) OVER () as SalesPercentage
FROM SalesOrder
JOIN Product ON SalesOrder.ProductID = Product.ProductID
GROUP BY ProductName
```

This query first calculates the total sales for each product, then calculates the percentage of each product's sales out of total sales using a window function.

**Use Case:** This can be used in a scenario where the sales department wants to analyze the contribution of each product to total sales.

### 3. How would you write a query to get the customers who have placed more than 10 orders in the last year?

```sql
SELECT CustomerName
FROM Customer
JOIN (
    SELECT CustomerID
    FROM Order
    WHERE OrderDate >= DATEADD(year, -1, GETDATE())
    GROUP BY CustomerID
    HAVING COUNT(OrderID) > 10
) tmp ON Customer.CustomerID = tmp.CustomerID
```

This query first filters the orders in the last year and groups them by `CustomerID`, then filters the customers who have placed more than 10 orders, and finally joins the result with the `Customer` table to get the customer names.

**Use Case:** This can be used in a scenario where the marketing department wants to reward loyal customers who have placed more than 10 orders in the last year.

### 4. How would you write a query to get the top 10% of customers who have spent the most?

```sql
SELECT TOP (10) PERCENT CustomerName, SUM(Amount) as TotalSpent
FROM Customer
JOIN Order ON Customer.CustomerID = Order.CustomerID
GROUP BY CustomerName
ORDER BY TotalSpent DESC
```

This query joins the `Customer` and `Order` tables, groups the result by `CustomerName`, calculates the total amount spent by each customer, and finally selects the top 10% of customers who have spent the most.

**Use Case:** This can be used in a scenario where the sales department wants to identify the top 10% of customers in terms of spending.

### 5. How would you write a query to get the month-over-month growth in sales?

```sql
SELECT YEAR(OrderDate) as Year, MONTH(OrderDate) as Month, 
SUM(Amount) as MonthlySales,
(SUM(Amount) - LAG(SUM(Amount), 1, 0) OVER (ORDER BY YEAR(OrderDate), MONTH(OrderDate))) / LAG(SUM(Amount), 1, 0) OVER (ORDER BY YEAR(OrderDate), MONTH(OrderDate)) as MoMGrowth
FROM SalesOrder
GROUP BY YEAR(OrderDate), MONTH(OrderDate)
ORDER BY Year, Month
```

This query first groups the sales orders by year and month, then calculates the total sales for each month and the month-over-month growth in sales using the `LAG` window function.

**Use Case:** This can be used in a scenario where the finance department wants to analyze the month-over-month growth in sales.