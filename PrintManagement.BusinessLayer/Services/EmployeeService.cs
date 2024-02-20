using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.DataLayer.Models;
using PrintManagement.DataLayer.Repositories.Interfaces;

namespace PrintManagement.BusinessLayer.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeerepository)
    {
        _employeeRepository = employeerepository;
    }

    public async Task<List<EmployeeDto>> GetAllEmployees() => await _employeeRepository.GetAllEmployees();
}
