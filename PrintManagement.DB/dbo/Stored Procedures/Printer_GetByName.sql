CREATE PROCEDURE [dbo].[Printer_GetByName]
	@PrinterName int

AS
BEGIN
	SELECT PrinterId
	FROM [dbo].[Printer]
	WHERE PrinterName=@PrinterName
END
