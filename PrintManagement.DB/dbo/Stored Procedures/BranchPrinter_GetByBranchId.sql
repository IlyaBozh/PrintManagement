﻿CREATE PROCEDURE [dbo].[BranchPrinter_GetByBranchId]
	@BranchId int 

AS
BEGIN
	SELECT 
		BranchPrinterId,
		PrinterSerialNumber,
		IsDefault
	FROM [dbo].[BranchPrinter]
	WHERE BranchId=@BranchId
END
