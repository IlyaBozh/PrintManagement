CREATE PROCEDURE [dbo].[Branch_GetByNameAndLocation]
	@BranchName nvarchar,
	@BranchLocation nvarchar

AS
BEGIN
	SELECT BranchId
	FROM [dbo].[Branch]
	WHERE BranchName=@BranchName AND BranchLocation=@BranchLocation
END
