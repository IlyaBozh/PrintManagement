using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IEmployeeRepository
{
    public Task<List<EmployeeDto>> GetAllEmployees();
    public Task<EmployeeDto> GetEmployeeById(int employeeId);
}
