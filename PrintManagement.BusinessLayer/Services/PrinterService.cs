using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Enums;
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

    public async Task<List<PrinterDto>> GetPrintersByConnectionType(ConnectionType connectionType)
    {
        var printers = await _printerRepository.GetAllPrinters();

        return printers.Where(printer => printer.ConnectionType == connectionType).ToList();
    }
}
