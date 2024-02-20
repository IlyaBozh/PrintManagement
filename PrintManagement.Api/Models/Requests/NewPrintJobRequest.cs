using System.ComponentModel.DataAnnotations;

namespace PrintManagement.Api.Models.Requests;

public class NewPrintJobRequest
{
    [Required(ErrorMessage = "Введите задания печати")]
    public string JobName { get; set; }

    [Required(ErrorMessage = "Введите сотрудника")]
    public int EmployeeId { get; set; }

    public int PrinterSerialNumber { get; set; }

    [Required(ErrorMessage = "Введите количество страниц")]
    public int PagesCount { get; set; }
}
