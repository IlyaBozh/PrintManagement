CREATE PROCEDURE [dbo].[Employee_GetById]
	@EmployeeId int

AS
BEGIN
	SELECT BranchId
	FROM [dbo].[Employee]
	WHERE EmployeeId=@EmployeeId
END
