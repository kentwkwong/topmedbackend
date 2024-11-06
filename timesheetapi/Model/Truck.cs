using System.ComponentModel.DataAnnotations;

namespace timesheetapi.Model;

public class Truck
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(3)]
    public string TruckNo { get; set; } = string.Empty;
    [MaxLength(100)]
    public string RepairNote { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Remarks { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}