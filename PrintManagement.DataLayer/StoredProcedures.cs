namespace PrintManagement.DataLayer;

public class StoredProcedures
{
    public const string Branch_GetAll = "Branch_GetAll";
    public const string Branch_GetByName = "Branch_GetByName";
    public const string Branch_GetByNameAndLocation = "Branch_GetByNameAndLocation";
    public const string Branch_GetById = "Branch_GetById";

    public const string Employee_GetAll = "Employee_GetAll";

    public const string Printer_GetAll = "Printer_GetAll";
    public const string Printer_GetByName = "Printer_GetByName";
    public const string Printer_GetById = "Printer_GetById";
    
    public const string BranchPrinter_Add = "BranchPrinter_Add";
    public const string BranchPrinter_Delete = "BranchPrinter_Delete";
    public const string BranchPrinter_GetAll = "BranchPrinter_GetAll";
    public const string BranchPrinter_GetById = "BranchPrinter_GetById";
    public const string BranchPrinter_GetByBranchId = "BranchPrinter_GetByBranchId";
    public const string BranchPrinter_UpdateIsDefault = "BranchPrinter_UpdateIsDefault";
   
    public const string PrintJob_Add = "PrintJob_Add";
}
