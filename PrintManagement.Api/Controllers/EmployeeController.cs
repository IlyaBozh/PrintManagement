using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Api.Models.Responses;
using PrintManagement.BusinessLayer.Services;
using PrintManagement.BusinessLayer.Services.Interfaces;

namespace PrintManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<AllEmployeeResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AllEmployeeResponse>>> GetAllEmployees()
    {
        var branches = await _employeeService.GetAllEmployees();
        return Ok(_mapper.Map<List<AllEmployeeResponse>>(branches));
    }
}
