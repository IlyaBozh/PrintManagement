using PrintManagement.DataLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IBranchService
{
    public Task<List<BranchDto>> GetAllBranches();
}
