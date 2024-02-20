namespace PrintManagement.Api.Models.Requests;

public class NewPrintJobRequest
{
    public string JobName { get; set; }
    public int EmployeeId { get; set; }
    public int PrinterSerialNumber { get; set; }
    public int PagesCount { get; set; }
}
