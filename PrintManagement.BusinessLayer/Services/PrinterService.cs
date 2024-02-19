using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;

namespace PrintManagement.BusinessLayer.Services;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;

    public PrinterService(IPrinterRepository printerRepository)
    {
        _printerRepository = printerRepository;
    }

    public async Task<List<PrinterDto>> GetAllPrinters() => await _printerRepository.GetAllPrinters();

    public async Task<List<PrinterDto>> GetPrintersByConnectionType(string connectionType) => await _printerRepository.GetPrintersByConnectionType(connectionType);
}
