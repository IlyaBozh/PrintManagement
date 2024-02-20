CREATE TABLE [dbo].[Printer]
(
	[PrinterId]        INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[PrinterName]      INT                   NOT NULL,
    [ConnectionType]   INT                   NOT NULL,
    [MACAddress]       NCHAR (20)                NULL
)