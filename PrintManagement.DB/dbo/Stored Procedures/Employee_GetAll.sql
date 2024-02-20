CREATE PROCEDURE [dbo].[Employee_GetAll]

AS
BEGIN
	SELECT
		EmployeeId,
		EmployeeName
	FROM dbo.Employee
END
