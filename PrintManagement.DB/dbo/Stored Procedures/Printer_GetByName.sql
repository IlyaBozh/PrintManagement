CREATE PROCEDURE [dbo].[Printer_GetByName]
	@PrinterName nvarchar

AS
BEGIN
	SELECT PrinterId
	FROM [dbo].[Printer]
	WHERE PrinterName=@PrinterName
END
