using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Api.Extentions;
using PrintManagement.Api.Models.Requests;
using PrintManagement.Api.Models.Responses;
using PrintManagement.BusinessLayer.Models;
using PrintManagement.BusinessLayer.Services;
using PrintManagement.BusinessLayer.Services.Interfaces;

namespace PrintManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchPrinterController : ControllerBase
{
    private readonly IBranchPrinterService _branchPrinterService;
    private readonly IMapper _mapper;

    public BranchPrinterController(IBranchPrinterService branchPrinterService, IMapper mapper)
    {
        _branchPrinterService = branchPrinterService;
        _mapper = mapper;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> AddInstallation(NewInstallationRequest newInstallation)
    {
        var result = await _branchPrinterService.AddInstallation(_mapper.Map<BranchPrinterModel>(newInstallation));

        return Created($"{this.GetUrl()}/{result}", result);
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(NewInstallationRequest), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<NewInstallationRequest>>> GetAllInstallations()
    {
        var instalations = await _branchPrinterService.GetAllInstallations();
        
        return Ok(_mapper.Map<List<NewInstallationRequest>>(instalations));
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(NewInstallationRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NewInstallationRequest>> GetInstallationById(int installationId)
    {
        var instalation = await _branchPrinterService.GetInstallationById(installationId);

        if (instalation == null)
            return NotFound();
        else
            return Ok(_mapper.Map<NewInstallationRequest>(instalation));
    }

    [HttpDelete("[action]")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NewInstallationRequest>> DeleteInstallationById(int installationId)
    {
        await _branchPrinterService.DeleteInstallation(installationId);

        return NoContent();
    }
}
