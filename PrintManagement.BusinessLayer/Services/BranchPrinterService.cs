using PrintManagement.BusinessLayer.Exceptions;
using PrintManagement.BusinessLayer.Models;
using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Enums;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;

namespace PrintManagement.BusinessLayer.Services;

public class BranchPrinterService : IBranchPrinterService
{
    private readonly IBranchPrinterRepository _branchPrinterRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IPrinterRepository _printerRepository;

    public BranchPrinterService(IBranchPrinterRepository branchPrinterRepository, IBranchRepository branchRepository, IPrinterRepository printerRepository)
    {
        _branchPrinterRepository = branchPrinterRepository;
        _branchRepository = branchRepository;
        _printerRepository = printerRepository;
    }

    public async Task<int> AddInstallation(BranchPrinterModel printerInstallationInfo)
    {
        var branchId = await GetBranchId(printerInstallationInfo.BranchName, printerInstallationInfo.BranchLocation);
        var printerId = await GetPrinterId(printerInstallationInfo.PrinterName);
        var branchPrinterDto = new BranchPrinterDto
        {
            PrinterId = printerId,
            BranchId = branchId,
            PrinterSerialNumber = await GetPrinterSerialNumber(printerInstallationInfo.BranchName, printerInstallationInfo.PrinterSerialNumber),
            IsDefault = await GetPrinterIsDefault(printerInstallationInfo.BranchName)
        };

        var result = await _branchPrinterRepository.AddInstallation(branchPrinterDto);
        
        return result;
    }

    public async Task DeleteInstallation(int installationId)
    {
        var branchPrinter = await _branchPrinterRepository.GetInstallationById(installationId);

        if (branchPrinter == null)
            throw new NotFoundException("Инсталляция не найдена");

        await _branchPrinterRepository.DeleteInstallation(installationId);

        if (branchPrinter != null && branchPrinter.IsDefault) 
        {
            await ChangPrinterIsDefault(branchPrinter);
        }
    }

    public async Task<List<BranchPrinterModel>> GetAllInstallations()
    {
        var branchPrinters = await _branchPrinterRepository.GetAllInstallations();
        var result = new List<BranchPrinterModel>();

        foreach (var branchPrinter in branchPrinters)
        {
            result.Add(await ConvertBranchPrinterDtoToBranchPrinterModel(branchPrinter));
        }

        return result;
    }


    public async Task<List<BranchPrinterModel>> GetInstallationsByBranchName(string branchName)
    {
        BranchName branchNameEnum;

        try
        {
            branchNameEnum = (BranchName)Enum.Parse(typeof(BranchName), branchName.Replace(' ', '_'));
        }
        catch
        {
            throw new IncorrectDataException("Неверное название филиала");
        }

        var branchPrinters = await _branchPrinterRepository.GetAllInstallations();
        var branches = await _branchRepository.GetBranchByName(branchNameEnum);

        var result = new List<BranchPrinterModel>();

        foreach (var branchPrinter in branchPrinters)
        {
            foreach(var branch in branches)
            {
                if(branch.BranchId == branchPrinter.BranchId)
                    result.Add(await ConvertBranchPrinterDtoToBranchPrinterModel(branchPrinter));
            }
        }

        return result;
    }

    public async Task<BranchPrinterModel> GetInstallationById(int installationId)
    {
        var branchPrinter = await _branchPrinterRepository.GetInstallationById(installationId);

        if (branchPrinter == null)
            throw new NotFoundException("Инсталляция не найдена");

        return await ConvertBranchPrinterDtoToBranchPrinterModel(branchPrinter);
    }

    
    
    private async Task<int> GetBranchId(BranchName branchName, BranchLocation branchLocation)
    {
        var branch = await _branchRepository.GetBranchByNameAndLocation(branchName, branchLocation);

        return branch.BranchId;
    }

    private async Task<int> GetPrinterId(PrinterName printerName)
    {
        var printer = await _printerRepository.GetPrinterByName(printerName);

        return printer.PrinterId;
    }

    private async Task<int> GetPrinterSerialNumber(BranchName branchName, int userSerialNumber)
    {
        var branches = await _branchRepository.GetBranchByName(branchName);
        var serialNumbers = new List<int>();

        foreach (var branch in branches) 
        {
            var branchPrinter = await _branchPrinterRepository.GetInstallationsByBranchId(branch.BranchId);

            foreach (var serialNumber in branchPrinter)
                serialNumbers.Add(serialNumber.PrinterSerialNumber);
        }

        if (serialNumbers.Count > 0 && serialNumbers.Contains(userSerialNumber))
            return serialNumbers.Max() + 1;
        else
            return serialNumbers.Count > 0 ? userSerialNumber : 1;
    }

    private async Task<bool> GetPrinterIsDefault(BranchName branchName)
    {
        var branches = await _branchRepository.GetBranchByName(branchName);

        foreach (var branch in branches)
        {
            var branchPrinter = await _branchPrinterRepository.GetInstallationsByBranchId(branch.BranchId);

            foreach(var serialNumber in branchPrinter)
            {
                if(serialNumber.IsDefault) 
                    return false;
            }
        }

        return true;
    }

    private async Task ChangPrinterIsDefault(BranchPrinterDto DeletedBranchPrinter)
    {
        var branchDto = await _branchRepository.GetBranchById(DeletedBranchPrinter.BranchId);

        var branches = await _branchRepository.GetBranchByName(branchDto.BranchName);

        foreach (var branch in branches)
        {
            var branchPrinter = await _branchPrinterRepository.GetInstallationsByBranchId(branch.BranchId);

            foreach (var serialNumber in branchPrinter)
            {
                await _branchPrinterRepository.UpdatePrinterIsDefault(serialNumber.BranchPrinterId, true);
                return;
            }
        }
    }

    private async Task<BranchPrinterModel> ConvertBranchPrinterDtoToBranchPrinterModel(BranchPrinterDto branchPrinterDto)
    {
        var branch = await _branchRepository.GetBranchById(branchPrinterDto.BranchId);
        var printer = await _printerRepository.GetPrinterById(branchPrinterDto.PrinterId);

        return new BranchPrinterModel
        {
            BranchName = branch.BranchName,
            BranchLocation = branch.BranchLocation,
            PrinterName = printer.PrinterName,
            PrinterSerialNumber = branchPrinterDto.PrinterSerialNumber,
            IsDefault = branchPrinterDto.IsDefault,
        };
    }
}
