using AutoMapper;
using PrintManagement.Api.Models.Requests;
using PrintManagement.Api.Models.Responses;
using PrintManagement.BusinessLayer.Models;
using PrintManagement.DataLayer.Enums;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.Api.Infrastructure;

public class MapperConfig : Profile
{
    public MapperConfig() 
    {
        CreateMap<BranchDto, AllBranchResponse>()
            .ForMember(b => b.BranchName, opt => opt.MapFrom(s => s.BranchName.ToString().Replace('_', ' ')))
            .ForMember(b => b.BranchLocation, opt => opt.MapFrom(s => s.BranchLocation.ToString().Replace('_', ' ')));
        
        CreateMap<EmployeeDto, AllEmployeeResponse>();

        CreateMap<NewPrintJobRequest, PrintJobModel>();
        
        CreateMap<PrinterDto, AllPrinterResponse>()
            .ForMember(b => b.PrinterName, opt => opt.MapFrom(s => s.PrinterName.ToString().Replace('_', ' ')))
            .ForMember(b => b.ConnectionType, opt => opt.MapFrom(s => s.ConnectionType.ToString().Replace('_', ' ')));
        
        CreateMap<BranchPrinterModel, NewInstallationRequest>()
            .ForMember(b => b.BranchName, opt => opt.MapFrom(s => s.BranchName.ToString().Replace('_', ' ')))
            .ForMember(b => b.BranchLocation, opt => opt.MapFrom(s => s.BranchLocation.ToString().Replace('_', ' ')))
            .ForMember(b => b.PrinterName, opt => opt.MapFrom(s => s.PrinterName.ToString().Replace('_', ' '))); 
        
        CreateMap<NewInstallationRequest, BranchPrinterModel>()
            .ForMember(b => b.BranchName, opt => opt.MapFrom(s => (BranchName)Enum.Parse(typeof(BranchName), s.BranchName.Replace(' ', '_'))))
            .ForMember(b => b.BranchLocation, opt => opt.MapFrom(s => (BranchLocation)Enum.Parse(typeof(BranchLocation), s.BranchLocation.Replace(' ', '_'))))
            .ForMember(b => b.PrinterName, opt => opt.MapFrom(s => (PrinterName)Enum.Parse(typeof(PrinterName), s.PrinterName.Replace(' ', '_'))));
    }
}
