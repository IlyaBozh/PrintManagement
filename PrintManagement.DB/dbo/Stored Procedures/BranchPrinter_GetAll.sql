CREATE PROCEDURE [dbo].[BranchPrinter_GetAll]

AS
BEGIN
	SELECT
		BranchPrinterId,
		PrinterSerialNumber,
		IsDefault,
		PrinterId,
		BranchId
	FROM dbo.BranchPrinter
END
