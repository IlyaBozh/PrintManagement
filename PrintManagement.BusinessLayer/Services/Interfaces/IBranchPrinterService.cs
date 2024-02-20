using PrintManagement.BusinessLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IBranchPrinterService
{
    public Task<int> AddInstallation(BranchPrinterModel printerInstallationInfo);
    public Task<List<BranchPrinterModel>> GetAllInstallations();
    public Task<BranchPrinterModel> GetInstallationById(int installationId);
    public Task DeleteInstallation(int installationId);
}
