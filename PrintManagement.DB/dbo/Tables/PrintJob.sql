CREATE TABLE [dbo].[PrintJob]
(
	[PrintJobId]                INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[JobName]                   NVARCHAR(255)         NOT NULL,
	[PagesCount]                INT                   NOT NULL,
	[JobStatus]                 BIT                   NOT NULL,
	[EmployeeId]                INT                   NOT NULL,
	[BranchPrinterId]           INT                   NOT NULL,
	FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([EmployeeId]),
	FOREIGN KEY ([BranchPrinterId]) REFERENCES [dbo].[BranchPrinter] ([BranchPrinterId])
)
