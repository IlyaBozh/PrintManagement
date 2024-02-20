using PrintManagement.BusinessLayer.Exceptions;
using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Enums;
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

    public async Task<List<PrinterDto>> GetPrintersByConnectionType(string connectionType)
    {
        ConnectionType connectionTypeEnum;

        try
        {
            connectionTypeEnum = (ConnectionType)Enum.Parse(typeof(ConnectionType), connectionType.Replace(' ', '_'));
        }
        catch 
        {
            throw new IncorrectDataException("Введен неверный тип подключения устройства");
        }

        var printers = await _printerRepository.GetAllPrinters();

        return printers.Where(printer => printer.ConnectionType == connectionTypeEnum).ToList();
    }
}
