using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Reflection;

namespace PrintManagement.BusinessLayer.Services;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;

    public PrinterService(IPrinterRepository printerRepository)
    {
        _printerRepository = printerRepository;
    }

    public async Task<List<PrinterDto>> GetAllPrinters() => await _printerRepository.GetAllPrinters();

    public async Task<List<PrinterDto>> GetPrintersByConnectionType(string connectionType)
    {
        var printers = await _printerRepository.GetAllPrinters();

        return printers.Where(printer => string.Concat(printer.ConnectionType.Where(c => !char.IsWhiteSpace(c))) == connectionType).ToList();
    }
}
