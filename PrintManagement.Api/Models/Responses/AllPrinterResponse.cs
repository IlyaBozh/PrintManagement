namespace PrintManagement.Api.Models.Responses;

public class AllPrinterResponse
{
    public string PrinterName { get; set; }
    public string ConnectionType { get; set; }
    public string? MACAddress { get; set; }
}
