using Microsoft.VisualBasic.FileIO;
using PrintManagement.BusinessLayer.Models;
using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Text;

namespace PrintManagement.BusinessLayer.Services;

public class PrintJobService : IPrintJobService
{
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IBranchPrinterRepository _branchPrinterRepository;

    public PrintJobService(IPrintJobRepository printJobRepository, 
        IEmployeeRepository employeeRepository, 
        IBranchRepository branchRepository,
        IBranchPrinterRepository branchPrinterRepository)
    {
        _printJobRepository = printJobRepository;
        _employeeRepository = employeeRepository;
        _branchRepository = branchRepository;
        _branchPrinterRepository = branchPrinterRepository;
    }

    public async Task<int> RegistrationJob(PrintJobModel printJob)
    {
        var branchPrinterId = await GetBranchPrinterId(printJob);

        Random r = new Random();

        var printJobDto = new PrintJobDto
        {
            JobName = printJob.JobName,
            PagesCount = printJob.PagesCount,
            JobStatus = r.Next(2) == 1,
            EmployeeId = printJob.EmployeeId,
            BranchPrinterId = branchPrinterId
        };

        var result = await _printJobRepository.RegistrationJob(printJobDto);

        return result;
    }

    public async Task RegistrationJobFromCSV(Stream file)
    {
        int count = 0;

        using (var parser = new TextFieldParser(file))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                if (count == 100)
                    break;

                string[] fields = parser.ReadFields();

                var data = fields[0].Split(';');

                if (data.Count() != 4)
                    continue;

                var printJob = new PrintJobModel
                {
                    JobName = data[0],
                    EmployeeId = int.Parse(data[1]),
                    PrinterSerialNumber = int.Parse(data[2]),
                    PagesCount = int.Parse(data[3])
                };

                await RegistrationJob(printJob);
                count++;
            }
        }
    }

    private async Task<int> GetBranchPrinterId(PrintJobModel printJob)
    {
        var employee = await _employeeRepository.GetEmployeeById(printJob.EmployeeId);
        var employeeBranch = await _branchRepository.GetBranchById(employee.BranchId);
        var branches = await _branchRepository.GetBranchByName(employeeBranch.BranchName);

        var actualBranchPrinter = new BranchPrinterDto();
        var allSerialNumberInBranch = new List<BranchPrinterDto>();

        foreach (var branch in branches)
        {
            var BranchPrinters = await _branchPrinterRepository.GetInstallationsByBranchId(branch.BranchId);

            foreach (var branchPrinter in BranchPrinters)
            {
                if (branchPrinter.IsDefault)
                    actualBranchPrinter = branchPrinter;
                allSerialNumberInBranch.Add(branchPrinter);
            }
        }

        foreach (var branchPrinter in allSerialNumberInBranch)
        {
            if (printJob.PrinterSerialNumber == branchPrinter.PrinterSerialNumber)
                actualBranchPrinter = branchPrinter;
        }

        return actualBranchPrinter.BranchPrinterId;
    }
}
