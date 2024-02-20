using System.ComponentModel.DataAnnotations;

namespace PrintManagement.Api.Models.Requests;

public class NewInstallationRequest
{
    [Required(ErrorMessage = "Введите филиал")]
    public string BranchName { get; set; }

    [Required(ErrorMessage = "Введите наименование инсталляции")]
    public string BranchLocation { get; set; }

    [Required(ErrorMessage = "Введите устройство печати")]
    public string PrinterName { get; set; }

    public int PrinterSerialNumber { get; set; }

    [Required(ErrorMessage = "Введите признак использования")]
    public bool IsDefault { get; set; }
}
