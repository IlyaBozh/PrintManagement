CREATE PROCEDURE [dbo].[BranchPrinter_UpdateIsDefault]
	@BranchPrinterId int,
	@IsDefault bit

AS
BEGIN
	UPDATE [dbo].BranchPrinter
	SET IsDefault = @IsDefault
	WHERE BranchPrinterId=@BranchPrinterId
END
