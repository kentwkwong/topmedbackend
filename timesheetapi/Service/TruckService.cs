using Microsoft.EntityFrameworkCore;
using timesheetapi.Data;
using timesheetapi.Model;

namespace timesheetapi.Service;

public class TruckService
{
    private readonly ApiDbContext _context;

    public TruckService(ApiDbContext context)
    {
        _context = context;
    }
    
    public Truck? GetTruckById(Guid id)
    {
        return _context.Trucks.FirstOrDefault(x  => x.Id == id);
    }
    
    public void AddTruck(Truck obj)
    {
        _context.Trucks.Add(obj);
        _context.SaveChanges();
    }
    public bool UpdateTruck(Truck obj)
    {
        var record = _context.Trucks.FirstOrDefault(x => x.Id == obj.Id);
        if (record != null)
        {
            _context.Entry(record).State = EntityState.Detached;
            _context.Trucks.Update(obj);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
    
    public bool DeleteTruck(Guid id)
    {
        var record = _context.Trucks.FirstOrDefault(x => x.Id == id);
        if (record != null)
        {
            _context.Trucks.Remove(record);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}