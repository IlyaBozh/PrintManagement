using Dapper;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Data;
using System.Diagnostics.Metrics;

namespace PrintManagement.DataLayer.Repositories;

public class PrintJobRepository : BaseRepository, IPrintJobRepository
{
    public PrintJobRepository(IDbConnection connection) : base(connection) { }

    public async Task<int> RegistrationJob(PrintJobDto printJob)
    {
        var id = await _connectionString.QuerySingleAsync<int>(
            StoredProcedures.PrintJob_Add,
            param: new
            {
                printJob.JobName,
                printJob.PagesCount,
                printJob.JobStatus,
                printJob.EmployeeId,
                printJob.BranchPrinterId
            },
            commandType: CommandType.StoredProcedure);

        return id;
    }
}
