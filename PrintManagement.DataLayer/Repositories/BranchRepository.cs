using Dapper;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Data;

namespace PrintManagement.DataLayer.Repositories;

public class BranchRepository : BaseRepository, IBranchRepository
{
    public BranchRepository(IDbConnection connection) : base(connection) { }
    
    public async Task<List<BranchDto>> GetAllBranches()
    {
        var branches = (await _connectionString.QueryAsync<BranchDto>(
            StoredProcedures.Branch_GetAll,
            commandType: CommandType.StoredProcedure))
            .ToList();

        return branches;
    }
}
