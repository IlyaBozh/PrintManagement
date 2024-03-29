﻿using Dapper;
using PrintManagement.DataLayer.Enums;
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

    public async Task<BranchDto> GetBranchById(int branchId)
    {
        var branche = (await _connectionString.QueryAsync<BranchDto>(
            StoredProcedures.Branch_GetById,
            param: new { branchId },
            commandType: CommandType.StoredProcedure))
            .FirstOrDefault();
        return branche;
    }

    public async Task<List<BranchDto>> GetBranchByName(BranchName branchName)
    {
        var branches = (await _connectionString.QueryAsync<BranchDto>(
            StoredProcedures.Branch_GetByName,
            param: new { branchName },
            commandType: CommandType.StoredProcedure))
            .ToList();

        return branches;
    }

    public async Task<BranchDto> GetBranchByNameAndLocation(BranchName branchName, BranchLocation branchLocation)
    {
        var branche = (await _connectionString.QueryAsync<BranchDto>(
            StoredProcedures.Branch_GetByNameAndLocation,
            param: new { branchName, branchLocation },
            commandType: CommandType.StoredProcedure))
            .FirstOrDefault();

        return branche;
    }
}
