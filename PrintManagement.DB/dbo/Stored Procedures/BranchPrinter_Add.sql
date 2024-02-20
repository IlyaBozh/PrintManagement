CREATE PROCEDURE [dbo].[BranchPrinter_Add]
	@PrinterSerialNumber int,
	@IsDefault bit,
	@PrinterId int,
	@BranchId int

AS
BEGIN
	INSERT INTO [dbo].[BranchPrinter](
		PrinterSerialNumber,
		IsDefault,
		PrinterId,
		BranchId)
	VALUES(
		@PrinterSerialNumber,
		@IsDefault,
		@PrinterId,
		@BranchId)
	SELECT @@IDENTITY
END
