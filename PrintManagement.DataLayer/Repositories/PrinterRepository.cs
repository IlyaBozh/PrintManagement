using Dapper;
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
}
