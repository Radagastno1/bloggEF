using LOGIC;
using CORE;
using Microsoft.EntityFrameworkCore;

namespace DATABASE.Repositories;
public class LogInRepository : ILogInRepository
{
    MyDbContext _db;
    public LogInRepository(MyDbContext db)
    {
        _db = db;
    }
    public async Task<Author> TryLogInAsync(string email, string password)
    {
        return await _db.Authors.Where(a => a.Email == email && a.Password == password).FirstAsync();
    }
}