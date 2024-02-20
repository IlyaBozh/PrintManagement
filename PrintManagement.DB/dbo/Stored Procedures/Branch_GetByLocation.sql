CREATE PROCEDURE [dbo].[Branch_GetByLocation]
	@BranchLocation nvarchar

AS
BEGIN
	SELECT BranchId
	FROM [dbo].[Branch]
	WHERE BranchLocation=@BranchLocation
END
