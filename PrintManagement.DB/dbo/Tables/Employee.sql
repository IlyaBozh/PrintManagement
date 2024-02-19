CREATE TABLE [dbo].[Employee]
(
	[EmployeeId]                INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[EmployeeName]              NVARCHAR(50)          NOT NULL,
	[BranchId]                  INT                   NOT NULL,
	FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([BranchId])
)
