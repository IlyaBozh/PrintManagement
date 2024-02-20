CREATE PROCEDURE [dbo].[Branch_GetByNameAndLocation]
	@BranchName int,
	@BranchLocation int

AS
BEGIN
	SELECT BranchId
	FROM [dbo].[Branch]
	WHERE BranchName=@BranchName AND BranchLocation=@BranchLocation
END
