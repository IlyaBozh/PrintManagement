CREATE PROCEDURE [dbo].[Printer_GetAll]

AS
BEGIN
	SELECT
		PrinterId,
		PrinterName,
		ConnectionType,
		MACAddress
	FROM dbo.Printer

END
