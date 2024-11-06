using Microsoft.EntityFrameworkCore;
using timesheetapi.Data;
using timesheetapi.Model;

namespace timesheetapi.Service;

public class TimesheetService
{
    private readonly ApiDbContext _context;

    public TimesheetService(ApiDbContext context)
    {
        _context = context;
    }
    
    public Timesheet? GetTimesheetById(Guid id)
    {
        return _context.Timesheets.FirstOrDefault(x  => x.Id == id);
    }
    
    public void AddTimesheet(Timesheet obj)
    {
        _context.Timesheets.Add(obj);
        _context.SaveChanges();
    }
    public bool UpdateTimesheet(Timesheet obj)
    {
        var record = _context.Timesheets.FirstOrDefault(x => x.Id == obj.Id);
        if (record != null)
        {
            _context.Entry(record).State = EntityState.Detached;
            _context.Timesheets.Update(obj);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
    
    public bool DeleteTimesheet(Guid id)
    {
        var record = _context.Timesheets.FirstOrDefault(x => x.Id == id);
        if (record != null)
        {
            _context.Timesheets.Remove(record);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}