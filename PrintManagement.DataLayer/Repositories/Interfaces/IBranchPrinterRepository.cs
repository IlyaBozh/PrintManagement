using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IBranchPrinterRepository
{
    public Task<int> AddInstallation(BranchPrinterDto printerInstallationInfo);
    public Task<List<BranchPrinterDto>> GetAllInstallations();
    public Task<BranchPrinterDto> GetInstallationById(int installationId);
    public Task DeleteInstallation(int installationId);
}
