using PrintManagement.DataLayer.Models;

namespace PrintManagement.DataLayer.Repositories.Interfaces;

public interface IPrintJobRepository
{
    public Task<int> RegistrationJob(PrintJobDto printJob);
}
