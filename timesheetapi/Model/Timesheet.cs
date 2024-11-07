using System.ComponentModel.DataAnnotations;

namespace timesheetapi.Model;

public class Timesheet
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string DisplayName { get; set; }
    public string[] PartnersName { get; set; }
    public DateTime WorkFrom { get; set; }
    public DateTime WorkTo { get; set; }
    public int TruckNum { get; set; }
    public bool HasLunch { get; set; }
    public int BreaksCount { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
}