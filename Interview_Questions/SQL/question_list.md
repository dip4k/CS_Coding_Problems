# Question list 1

Sure, here are some SQL query interview questions categorized by their difficulty level. Each question is described in plain English.

### **Basic**

1. **Retrieve all records from a table.**

   - Problem: Write a query to select all columns from the `Employees` table.

2. **Select specific columns from a table.**

   - Problem: Write a query to select the `EmployeeName` and `Salary` columns from the `Employees` table.

3. **Filter records based on a condition.**

   - Problem: Write a query to select all employees with a salary greater than 50000.

4. **Sort records in ascending order.**

   - Problem: Write a query to select all employees and sort them by their `EmployeeName` in ascending order.

5. **Sort records in descending order.**

   - Problem: Write a query to select all employees and sort them by their `Salary` in descending order.

6. **Count the number of records in a table.**

   - Problem: Write a query to count the number of employees in the `Employees` table.

7. **Find the maximum value in a column.**

   - Problem: Write a query to find the highest salary in the `Employees` table.

8. **Find the minimum value in a column.**

   - Problem: Write a query to find the lowest salary in the `Employees` table.

9. **Calculate the average value in a column.**

   - Problem: Write a query to calculate the average salary of employees.

10. **Sum the values in a column.**
    - Problem: Write a query to calculate the total salary of all employees.

### **Medium**

1. **Group records by a column and calculate aggregate values.**

   - Problem: Write a query to group employees by `DepartmentID` and calculate the average salary for each department.

2. **Filter groups based on a condition.**

   - Problem: Write a query to group employees by `DepartmentID` and select only those departments with an average salary greater than 60000.

3. **Join two tables and retrieve specific columns.**

   - Problem: Write a query to join the `Employees` table with the `Departments` table and select the `EmployeeName` and `DepartmentName`.

4. **Join two tables and filter the results.**

   - Problem: Write a query to join the `Employees` table with the `Departments` table and select employees who work in the 'Sales' department.

5. **Use a subquery to filter records.**

   - Problem: Write a query to select employees whose salary is above the average salary of the company.

6. **Use a subquery in the SELECT clause.**

   - Problem: Write a query to select employees and include a column that shows the average salary of their department.

7. **Use a subquery in the FROM clause.**

   - Problem: Write a query to select the average salary of each department and then select only those departments with an average salary greater than 60000.

8. **Retrieve the top N records.**

   - Problem: Write a query to select the top 5 highest-paid employees.

9. **Retrieve records with a specific pattern in a column.**

   - Problem: Write a query to select employees whose names start with 'A'.

10. **Use a CASE statement to create conditional columns.**
    - Problem: Write a query to select employees and include a column that shows 'High' if the salary is above 70000 and 'Low' otherwise.

### **Hard**

1. **Use a window function to rank records.**

   - Problem: Write a query to rank employees by their salary within their department.

2. **Calculate a running total using a window function.**

   - Problem: Write a query to calculate the running total of salaries within each department.

3. **Calculate the difference between consecutive rows using a window function.**

   - Problem: Write a query to calculate the difference between each employee's salary and the previous employee's salary within their department.

4. **Use a window function to calculate a moving average.**

   - Problem: Write a query to calculate the moving average of salaries within each department over the last 3 employees.

5. **Use a window function to calculate the cumulative distribution.**

   - Problem: Write a query to calculate the cumulative distribution of salaries within each department.

6. **Use a window function to retrieve the nth value.**

   - Problem: Write a query to retrieve the 3rd highest salary within each department.

7. **Use a window function to calculate the percentage of total.**

   - Problem: Write a query to calculate the percentage of the total salary within each department for each employee.

8. **Use a window function to assign dense ranks.**

   - Problem: Write a query to assign dense ranks to employees by salary within their department.

9. **Use a window function to divide records into quartiles.**

   - Problem: Write a query to divide employees' salaries within each department into 4 quartiles.

10. **Use a recursive Common Table Expression (CTE).**

    - Problem: Write a query to generate a sequence of numbers from 1 to 10 using a recursive CTE.

11. **Perform a self-join.**

    - Problem: Write a query to find pairs of employees who work in the same department.

12. **Find gaps in a sequence.**

    - Problem: Write a query to find missing employee IDs in a sequence of employee IDs.

13. **Pivot data from rows to columns.**

    - Problem: Write a query to pivot the `Sales` table so that each row represents a month and each column represents a product.

14. **Unpivot data from columns to rows.**

    - Problem: Write a query to unpivot the `Sales` table so that each row represents a product and a month.

15. **Use a window function to calculate the lag of a value.**

    - Problem: Write a query to calculate the lag of each employee's salary within their department.

16. **Use a window function to calculate the lead of a value.**

    - Problem: Write a query to calculate the lead of each employee's salary within their department.

17. **Use a window function to calculate the first value in a partition.**

    - Problem: Write a query to retrieve the first salary within each department.

18. **Use a window function to calculate the last value in a partition.**

    - Problem: Write a query to retrieve the last salary within each department.

19. **Use a window function to calculate the nth value in a partition.**

    - Problem: Write a query to retrieve the 2nd highest salary within each department.

20. **Combine multiple window functions in a single query.**
    - Problem: Write a query to calculate the rank, dense rank, and row number of each employee's salary within their department.

---

---

# Question List 2

### **Easy**

1. **Question:** Write a query to retrieve all columns from the `Employees` table.
2. **Question:** Write a query to retrieve the `EmployeeName` and `Salary` columns from the `Employees` table.
3. **Question:** Write a query to find the number of employees in the `Employees` table.
4. **Question:** Write a query to find the maximum salary in the `Employees` table.
5. **Question:** Write a query to find the minimum salary in the `Employees` table.
6. **Question:** Write a query to find the average salary in the `Employees` table.
7. **Question:** Write a query to find the total salary paid to all employees.
8. **Question:** Write a query to retrieve the names of employees who have a salary greater than 50000.
9. **Question:** Write a query to retrieve the names of employees who work in the 'Sales' department.
10. **Question:** Write a query to retrieve the names of employees who were hired after January 1, 2020.
11. **Question:** Write a query to retrieve the distinct job titles from the `Employees` table.
12. **Question:** Write a query to sort the employees by their `EmployeeName` in ascending order.
13. **Question:** Write a query to sort the employees by their `Salary` in descending order.
14. **Question:** Write a query to retrieve the top 5 highest-paid employees.
15. **Question:** Write a query to retrieve the names of employees whose names start with the letter 'A'.
16. **Question:** Write a query to retrieve the names of employees whose names end with the letter 'n'.
17. **Question:** Write a query to retrieve the names of employees whose names contain the letter 'e'.
18. **Question:** Write a query to retrieve the names of employees who do not have a manager.
19. **Question:** Write a query to retrieve the names of employees along with their department names.
20. **Question:** Write a query to retrieve the names of employees who have the same job title as 'John Doe'.

### **Medium**

1. **Question:** Write a query to find the second highest salary in the `Employees` table.
2. **Question:** Write a query to find the employees who have the same salary.
3. **Question:** Write a query to retrieve the names of employees along with their manager's name.
4. **Question:** Write a query to find the department with the highest number of employees.
5. **Question:** Write a query to find the department with the lowest number of employees.
6. **Question:** Write a query to find the average salary for each department.
7. **Question:** Write a query to find the total salary paid to employees in each department.
8. **Question:** Write a query to find the employees who earn more than the average salary of their department.
9. **Question:** Write a query to find the employees who earn the highest salary in their department.
10. **Question:** Write a query to find the employees who earn the lowest salary in their department.
11. **Question:** Write a query to find the employees who have been with the company for more than 5 years.
12. **Question:** Write a query to find the employees who have been with the company for less than 1 year.
13. **Question:** Write a query to find the employees who were hired in the last 6 months.
14. **Question:** Write a query to find the employees who were hired in the last year.
15. **Question:** Write a query to find the employees who were hired in the last 30 days.
16. **Question:** Write a query to find the employees who were hired in the last week.
17. **Question:** Write a query to find the employees who were hired on a specific date.
18. **Question:** Write a query to find the employees who were hired in a specific month.
19. **Question:** Write a query to find the employees who were hired in a specific year.
20. **Question:** Write a query to find the employees who were hired between two specific dates.

### **Hard**

1. **Question:** Write a query to find the nth highest salary in the `Employees` table.
2. **Question:** Write a query to find the employees who have the same manager.
3. **Question:** Write a query to find the employees who do not have any subordinates.
4. **Question:** Write a query to find the employees who have more than one manager.
5. **Question:** Write a query to find the employees who have worked in more than one department.
6. **Question:** Write a query to find the employees who have the highest salary in each department.
7. **Question:** Write a query to find the employees who have the lowest salary in each department.
8. **Question:** Write a query to find the employees who have the highest salary in each job title.
9. **Question:** Write a query to find the employees who have the lowest salary in each job title.
10. **Question:** Write a query to find the employees who have the highest salary in each location.
11. **Question:** Write a query to find the employees who have the lowest salary in each location.
12. **Question:** Write a query to find the employees who have the highest salary in each department and job title.
13. **Question:** Write a query to find the employees who have the lowest salary in each department and job title.
14. **Question:** Write a query to find the employees who have the highest salary in each department and location.
15. **Question:** Write a query to find the employees who have the lowest salary in each department and location.
16. **Question:** Write a query to find the employees who have the highest salary in each job title and location.
17. **Question:** Write a query to find the employees who have the lowest salary in each job title and location.
18. **Question:** Write a query to find the employees who have the highest salary in each department, job title, and location.
19. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, and location.
20. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, and manager.
21. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, location, and manager.
22. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, manager, and hire date.
23. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, location, manager, and hire date.
24. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, manager, hire date, and gender.
25. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, location, manager, hire date, and gender.
26. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, manager, hire date, gender, and age.
27. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, location, manager, hire date, gender, and age.
28. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, manager, hire date, gender, age, and education level.
29. **Question:** Write a query to find the employees who have the lowest salary in each department, job title, location, manager, hire date, gender, age, and education level.
30. **Question:** Write a query to find the employees who have the highest salary in each department, job title, location, manager, hire date, gender, age, education level, and marital status.
