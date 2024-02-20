namespace PrintManagement.DataLayer.Models;

public class BranchPrinterDto
{
    public int BranchPrinterId { get; set; }
    public int PrinterSerialNumber { get; set; }
    public bool IsDefault { get; set; }
    public int PrinterId { get; set; }
    public int BranchId { get; set; }
}
