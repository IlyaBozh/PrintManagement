namespace PrintManagement.DataLayer.Models;

public class PrinterDto
{
    public int PrinterId { get; set; }
    public string PrinterName { get; set; }
    public string ConnectionType { get; set; }
    public string? MACAddress { get; set; }
}
