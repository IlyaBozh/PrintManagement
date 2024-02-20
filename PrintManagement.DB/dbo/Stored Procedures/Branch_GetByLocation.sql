CREATE PROCEDURE [dbo].[Branch_GetByName]
	@BranchName int

AS
BEGIN
	SELECT BranchId
	FROM [dbo].[Branch]
	WHERE BranchName=@BranchName
END
