CREATE PROCEDURE total_emp(@DepartmentID INT)
AS
BEGIN
SELECT COUNT(e.EmployeeID) AS TOTAL_EMPLOYEES, d.DepartmentName FROM Employees e
INNER JOIN Departments d on e.DepartmentID=d.DepartmentID
where e.DepartmentID=@DepartmentID GROUP BY d.DepartmentName;
END;
SELECT * FROM Employees;
SELECT * FROM Departments;
EXECUTE total_emp 1;