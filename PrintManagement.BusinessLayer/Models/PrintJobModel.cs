namespace PrintManagement.BusinessLayer.Models;

public class PrintJobModel
{
    public string JobName { get; set; }
    public int EmployeeId { get; set; }
    public int PrinterSerialNumber { get; set; }
    public int PagesCount { get; set; }
}
