using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IPrinterRepository
{
    public Task<List<PrinterDto>> GetAllPrinters();
    public Task<List<PrinterDto>> GetPrintersByConnectionType(string connectionType);
}
