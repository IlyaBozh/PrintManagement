using PrintManagement.BusinessLayer.Models;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IBranchPrinterService
{
    public Task<int> AddInstallation(BranchPrinterModel printerInstallationInfo);
    public Task<List<BranchPrinterModel>> GetAllInstallations();
    public Task<List<BranchPrinterModel>> GetInstallationsByBranchName(string branchName);
    public Task<BranchPrinterModel> GetInstallationById(int installationId);
    public Task DeleteInstallation(int installationId);
}
