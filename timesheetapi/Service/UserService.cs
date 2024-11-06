using Microsoft.EntityFrameworkCore;
using timesheetapi.Data;
using timesheetapi.Model;

namespace timesheetapi.Service;

public class UserService
{
    private readonly ApiDbContext _context;

    public UserService(ApiDbContext context)
    {
        _context = context;
    }
    
    public List<User> GetAllUsers() => _context.Users.ToList();

    public User? GetUserById(Guid id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public bool UpdateUser(User user)
    {
        var record = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (record != null)
        {
            _context.Entry(record).State = EntityState.Detached;
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool DeleteUser(Guid id)
    {
        var record = _context.Users.FirstOrDefault(x => x.Id == id);
        if (record != null)
        {
            _context.Users.Remove(record);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}