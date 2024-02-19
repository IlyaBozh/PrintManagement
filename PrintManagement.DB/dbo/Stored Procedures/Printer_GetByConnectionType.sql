CREATE PROCEDURE [dbo].[Printer_GetByConnectionType]
	@ConnectionType nvarchar

AS
BEGIN
	SELECT
		PrinterId,
		PrinterName,
		ConnectionType,
		MACAddress
	FROM dbo.Printer
	WHERE ConnectionType = @ConnectionType
END