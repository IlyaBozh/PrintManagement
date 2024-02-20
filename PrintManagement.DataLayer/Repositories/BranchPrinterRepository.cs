using Dapper;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Data;

namespace PrintManagement.DataLayer.Repositories;

public class BranchPrinterRepository : BaseRepository, IBranchPrinterRepository
{
    public BranchPrinterRepository(IDbConnection connection) : base(connection) { }

    public async Task<int> AddInstallation(BranchPrinterDto printerInstallationInfo)
    {
        var id = await _connectionString.QuerySingleAsync<int>(
            StoredProcedures.BranchPrinter_Add,
            param: new
            {
                printerInstallationInfo.PrinterSerialNumber,
                printerInstallationInfo.IsDefault,
                printerInstallationInfo.PrinterId,
                printerInstallationInfo.BranchId
            },
            commandType: CommandType.StoredProcedure);

        return id;
    }

    public async Task DeleteInstallation(int installationId)
    {
        await _connectionString.ExecuteAsync(
            StoredProcedures.BranchPrinter_Delete,
            param: new { installationId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<List<BranchPrinterDto>> GetAllInstallations()
    {
        var installations = (await _connectionString.QueryAsync<BranchPrinterDto>(
            StoredProcedures.BranchPrinter_GetAll,
            commandType: CommandType.StoredProcedure))
            .ToList();
        
        return installations;
    }

    public async Task<BranchPrinterDto> GetInstallationById(int installationId)
    {
        var installation = (await _connectionString.QueryAsync<BranchPrinterDto>(
            StoredProcedures.BranchPrinter_GetById,
            param: new { installationId },
            commandType: CommandType.StoredProcedure))
            .FirstOrDefault();

        return installation;
    }

    public async Task<List<BranchPrinterDto>> GetInstallationsByBranchId(int branchId)
    {
        var installations = (await _connectionString.QueryAsync<BranchPrinterDto>(
            StoredProcedures.BranchPrinter_GetByBranchId,
            param: new { branchId },
            commandType: CommandType.StoredProcedure))
            .ToList();

        return installations;
    }

    public async Task UpdatePrinterIsDefault(int branchPrinterId, bool isDefault)
    {
        await _connectionString.ExecuteAsync(
            StoredProcedures.BranchPrinter_UpdateIsDefault,
            param: new { branchPrinterId, isDefault },
            commandType: CommandType.StoredProcedure);
    }
}
