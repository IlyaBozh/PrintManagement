CREATE PROCEDURE [dbo].[BranchPrinter_GetByBranchId]
	@BranchId int 

AS
BEGIN
	SELECT PrinterSerialNumber
	FROM [dbo].[BranchPrinter]
	WHERE BranchId=@BranchId
END
