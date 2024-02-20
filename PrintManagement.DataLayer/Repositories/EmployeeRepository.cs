using Dapper;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;
using System.Data;

namespace PrintManagement.DataLayer.Repositories;

public class EmployeeRepository : BaseRepository, IEmployeeRepository
{
    public EmployeeRepository(IDbConnection connection) : base(connection) { }

    public async Task<List<EmployeeDto>> GetAllEmployees()
    {
        var employees = (await _connectionString.QueryAsync<EmployeeDto>(
            StoredProcedures.Employee_GetAll,
            commandType: CommandType.StoredProcedure))
            .ToList();

        return employees;
    }
}
