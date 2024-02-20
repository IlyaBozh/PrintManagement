using Dapper;
using PrintManagement.DataLayer.Enums;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Data;

namespace PrintManagement.DataLayer.Repositories;

public class PrinterRepository : BaseRepository, IPrinterRepository
{
    public PrinterRepository(IDbConnection connection) : base(connection) { }
    
    public async Task<List<PrinterDto>> GetAllPrinters()
    {
        var printers = (await _connectionString.QueryAsync<PrinterDto>(
            StoredProcedures.Printer_GetAll,
            commandType: CommandType.StoredProcedure))
            .ToList();

        return printers;
    }

    public async Task<PrinterDto> GetPrinterById(int printerId)
    {
        var printer = (await _connectionString.QueryAsync<PrinterDto>(
           StoredProcedures.Printer_GetById,
           param: new { printerId },
           commandType: CommandType.StoredProcedure))
           .FirstOrDefault();
        return printer;
    }

    public async Task<PrinterDto> GetPrinterByName(PrinterName printerName)
    {
        var printer = (await _connectionString.QueryAsync<PrinterDto>(
           StoredProcedures.Printer_GetByName,
           param: new { printerName },
           commandType: CommandType.StoredProcedure))
           .FirstOrDefault();

        return printer;
    }
}
