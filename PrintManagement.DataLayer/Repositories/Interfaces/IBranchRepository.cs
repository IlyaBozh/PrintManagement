using PrintManagement.DataLayer.Enums;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IBranchRepository
{
    public Task<List<BranchDto>> GetAllBranches();
    public Task<BranchDto> GetBranchByNameAndLocation(BranchName branchName, BranchLocation branchLocation);
    public Task<List<BranchDto>> GetBranchByName(BranchName branchName);
    public Task<BranchDto> GetBranchById(int branchId);
}
