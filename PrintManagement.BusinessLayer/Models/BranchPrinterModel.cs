using PrintManagement.DataLayer.Enums;

namespace PrintManagement.BusinessLayer.Models;

public class BranchPrinterModel
{
    public BranchName BranchName { get; set; }
    public BranchLocation BranchLocation { get; set; }
    public PrinterName PrinterName { get; set; }
    public int PrinterSerialNumber { get; set; }
    public bool IsDefault { get; set; }
}
