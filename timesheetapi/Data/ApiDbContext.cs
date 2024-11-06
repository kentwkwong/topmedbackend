using Microsoft.EntityFrameworkCore;
using timesheetapi.Model;

namespace timesheetapi.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Truck> Trucks { get; set; }
    public virtual DbSet<Timesheet> Timesheets { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
}