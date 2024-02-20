CREATE PROCEDURE [dbo].[PrintJob_Add]
	@JobName nvarchar(100),
	@PagesCount int,
	@JobStatus bit,
	@EmployeeId int,
	@BranchPrinterId int

AS
BEGIN
	INSERT INTO [dbo].PrintJob(
		JobName,
		PagesCount,
		JobStatus,
		EmployeeId,
		BranchPrinterId)
	VALUES(
		@JobName,
		@PagesCount,
		@JobStatus,
		@EmployeeId,
		@BranchPrinterId)
	SELECT @@IDENTITY
END
