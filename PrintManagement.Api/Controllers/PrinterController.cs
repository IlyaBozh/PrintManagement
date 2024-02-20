using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Api.Models.Responses;
using PrintManagement.BusinessLayer.Services.Interfaces;

namespace PrintManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;
    private readonly IMapper _mapper;

    public PrinterController(IPrinterService employeeService, IMapper mapper)
    {
        _printerService = employeeService;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<AllPrinterResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AllPrinterResponse>>> GetAllPrinters()
    {
        var branches = await _printerService.GetAllPrinters();
        return Ok(_mapper.Map<List<AllPrinterResponse>>(branches));
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<AllPrinterResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AllPrinterResponse>>> GetPrintersByConnectionType(string connectionType)
    {
        var branches = await _printerService.GetPrintersByConnectionType(connectionType);

        return Ok(_mapper.Map<List<AllPrinterResponse>>(branches));
    }
}
