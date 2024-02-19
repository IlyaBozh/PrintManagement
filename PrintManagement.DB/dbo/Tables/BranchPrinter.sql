CREATE TABLE [dbo].[BranchPrinter]
(
	[BranchPrinterId]           INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[PrinterSerialNumber]       INT                   NOT NULL,
    [IsDefault]                 BIT DEFAULT 0         NOT NULL,
	[PrinterId]                 INT                   NOT NULL,
	[BranchId]                  INT                   NOT NULL,
	FOREIGN KEY ([PrinterId]) REFERENCES [dbo].[Printer] ([PrinterID]),
	FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([BranchId])
)
