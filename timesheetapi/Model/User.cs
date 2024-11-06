using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace timesheetapi.Model;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(20)]
    public string UserName { get; set; } = string.Empty;
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(50)]
    public string FullName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string DisplayName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ContactNo { get; set; } = string.Empty;
    [MaxLength(1)]
    public string Role { get; set; } = "U";
    [MaxLength(1)]
    public string Status { get; set; } = "A";
    public bool IsActive { get; set; }
}