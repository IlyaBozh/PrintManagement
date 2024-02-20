using PrintManagement.DataLayer.Enums;

namespace PrintManagement.DataLayer.Models;

public class PrinterDto
{
    public int PrinterId { get; set; }
    public PrinterName PrinterName { get; set; }
    public ConnectionType ConnectionType { get; set; }
    public string? MACAddress { get; set; }
}
