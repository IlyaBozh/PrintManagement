using PrintManagement.DataLayer.Enums;

namespace PrintManagement.DataLayer.Models;

public class BranchDto
{
    public int BranchId { get; set; }
    public BranchName BranchName { get; set; }
    public BranchLocation BranchLocation { get; set; }
}
