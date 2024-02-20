namespace PrintManagement.DataLayer.Models;

public class PrintJobDto
{
    public int PrintJobId { get; set; }
    public string JobName { get; set; }
    public int PagesCount { get; set; }
    public bool JobStatus { get; set; }
    public int EmployeeId { get; set; }
    public int BranchPrinterId { get; set; }
}
