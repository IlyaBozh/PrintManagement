using PrintManagement.BusinessLayer.Models;
using PrintManagement.DataLayer.Models;

namespace PrintManagement.BusinessLayer.Services.Interfaces;

public interface IPrintJobService
{
    public Task<int> RegistrationJob(PrintJobModel printJob);
}
