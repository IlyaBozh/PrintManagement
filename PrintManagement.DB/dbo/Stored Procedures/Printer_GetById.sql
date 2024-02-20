CREATE PROCEDURE [dbo].[Printer_GetById]
	@PrinterId int

AS
BEGIN
	SELECT 
		PrinterName,
		ConnectionType,
		MACAddress
	FROM [dbo].[Printer]
	WHERE PrinterId=@PrinterId
END
