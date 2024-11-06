using System.ComponentModel.DataAnnotations;

namespace timesheetapi.Model;

public class Timesheet
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime WorkFrom { get; set; }
    public DateTime WorkTo { get; set; }
    public Guid TruckId { get; set; }
    public bool IsLunch { get; set; }
    public int Breaks { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
}