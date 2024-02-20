using AutoMapper;
using PrintManagement.Api.Models.Responses;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.Api.Infrastructure;

public class MapperConfig : Profile
{
    public MapperConfig() 
    {
        CreateMap<BranchDto, AllBranchResponse>();
        CreateMap<EmployeeDto, AllEmployeeResponse>();
        CreateMap<PrinterDto, AllPrinterResponse>();
    }
}
