using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Api.Extentions;
using PrintManagement.Api.Models.Requests;
using PrintManagement.BusinessLayer.Models;
using PrintManagement.BusinessLayer.Services;
using PrintManagement.BusinessLayer.Services.Interfaces;

namespace PrintManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrintJobController : ControllerBase
{
    private readonly IPrintJobService _printJobService;
    private readonly IMapper _mapper;

    public PrintJobController(IPrintJobService printJobService, IMapper mapper)
    {
        _printJobService = printJobService;
        _mapper = mapper;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> RegistrationJob([FromBody] NewPrintJobRequest newPrintJob)
    {
        var result = await _printJobService.RegistrationJob(_mapper.Map<PrintJobModel>(newPrintJob));

        Thread.Sleep(5000);

        return Created($"{this.GetUrl()}/{result}", result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> RegistrationJobFromCSV([FromForm] IFormFileCollection file)
    {
        await _printJobService.RegistrationJobFromCSV(file[0].OpenReadStream());

        return NoContent();
    }
}
