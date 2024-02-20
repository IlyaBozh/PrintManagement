using PrintManagement.DataLayer.Enums;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IPrinterService
{
    public Task<List<PrinterDto>> GetAllPrinters();
    public Task<List<PrinterDto>> GetPrintersByConnectionType(string connectionType);
}
