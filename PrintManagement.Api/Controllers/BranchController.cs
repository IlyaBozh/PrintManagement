using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Api.Models.Responses;
using PrintManagement.BusinessLayer.Services.Interfaces;

namespace PrintManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IMapper _mapper;

    public BranchController(IBranchService branchService, IMapper mapper)
    {
        _branchService = branchService;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<AllBranchResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AllBranchResponse>>> GetAllBranches()
    {
        var branches = await _branchService.GetAllBranches();
        return Ok(_mapper.Map<List<AllBranchResponse>>(branches));
    }
}
