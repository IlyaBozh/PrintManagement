namespace PrintManagement.BusinessLayer.Models;

public class BranchPrinterModel
{
    public string BranchName { get; set; }
    public string BranchLocation { get; set; }
    public string PrinterName { get; set; }
    public int PrinterSerialNumber { get; set; }
    public bool IsDefault { get; set; }
}
