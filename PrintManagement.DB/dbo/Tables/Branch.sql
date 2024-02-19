CREATE TABLE [dbo].[Branch]
(
	[BranchId]         INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[BranchName]       NCHAR (255)           NOT NULL,
    [BranchLocation]   NCHAR (255)           NOT NULL
)
