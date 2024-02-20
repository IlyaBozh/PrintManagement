using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IPrinterRepository
{
    public Task<List<PrinterDto>> GetAllPrinters();
    public Task<PrinterDto> GetPrinterByName(string printerName);
    public Task<PrinterDto> GetPrinterById(int printerId);
}
