CREATE PROCEDURE [dbo].[BranchPrinter_GetById]
	@InstallationId int

AS
BEGIN
	SELECT
		BP.BranchPrinterId,
		BP.PrinterSerialNumber,
		BP.IsDefault,
		BP.PrinterId,
		BP.BranchId
	FROM [dbo].[BranchPrinter] AS BP
	WHERE BranchPrinterId=@InstallationId
END
