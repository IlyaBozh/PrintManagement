CREATE PROCEDURE [dbo].[Branch_GetById]
	@BranchId int

AS
BEGIN
	SELECT 
		BranchName,
		BranchLocation
	FROM [dbo].Branch
	WHERE BranchId=@BranchId 
END
