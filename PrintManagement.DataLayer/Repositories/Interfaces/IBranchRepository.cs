using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IBranchRepository
{
    public Task<List<BranchDto>> GetAllBranches();
}
