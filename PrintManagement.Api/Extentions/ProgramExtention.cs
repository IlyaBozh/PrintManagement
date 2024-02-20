using Microsoft.OpenApi.Models;
using PrintManagement.BusinessLayer.Services.Interfaces;
using PrintManagement.BusinessLayer.Services;
using PrintManagement.DataLayer.Repositories.Interfaces;
using PrintManagement.DataLayer.Repositories;

namespace PrintManagement.Api.Extentions;

public static class ProgramExtention
{
    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM", Version = "v1" });
        });
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPrinterRepository, PrinterRepository>();
        services.AddScoped<IBranchPrinterRepository, BranchPrinterRepository>();

        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPrinterService, PrinterService>();
        services.AddScoped<IBranchPrinterService, BranchPrinterService>();
    }
}
