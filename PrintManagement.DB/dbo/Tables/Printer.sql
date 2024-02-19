CREATE TABLE [dbo].[Printer]
(
	[PrinterId]        INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
	[PrinterName]      NCHAR (255)           NOT NULL,
    [ConnectionType]   NCHAR (50)            NOT NULL,
    [MACAddress]       NCHAR (20)                NULL
)