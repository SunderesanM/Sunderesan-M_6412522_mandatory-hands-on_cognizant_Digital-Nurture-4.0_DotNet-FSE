--Exercise 1: Create a Stored Procedure 
--Goal: Create a stored procedure to retrieve employee details by department. 

CREATE PROCEDURE Emp_Dept( @Department_Id INT )
AS
BEGIN
	SELECT EmployeeID,
			FirstName,
			LastName,
			DepartmentID,
			Salary,
			JoinDate
	FROM Employees
	WHERE DepartmentID=@Department_Id;
END;

SELECT * FROM Employees;
EXECUTE Emp_Dept @Department_Id=1;

--We can retrive any details of employee with respect to the departmentId