CREATE PROCEDURE [dbo].[BranchPrinter_Delete]
	@InstallationId int

AS
BEGIN
	DELETE FROM [dbo].[BranchPrinter]
	WHERE BranchPrinterId=@InstallationId
END
