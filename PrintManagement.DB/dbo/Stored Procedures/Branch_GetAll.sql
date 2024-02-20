CREATE PROCEDURE [dbo].[Branch_GetAll]

AS
BEGIN
	SELECT
		BranchId,
		BranchName,
		BranchLocation
	FROM dbo.Branch
END
