using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IBranchRepository
{
    public Task<List<BranchDto>> GetAllBranches();
    public Task<BranchDto> GetBranchByNameAndLocation(string branchName, string branchLocation);
    public Task<List<BranchDto>> GetBranchByLocation(string branchLocation);
    public Task<BranchDto> GetBranchById(int branchId);
}
