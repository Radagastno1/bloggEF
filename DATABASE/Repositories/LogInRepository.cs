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
    public Author TryLogIn(string email, string password)
    {
        return _db.Authors.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
    }
}