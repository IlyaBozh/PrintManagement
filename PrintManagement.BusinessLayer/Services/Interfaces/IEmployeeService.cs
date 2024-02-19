using PrintManagement.DataLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IEmployeeService
{
    public Task<List<EmployeeDto>> GetAllEmployees();
}
