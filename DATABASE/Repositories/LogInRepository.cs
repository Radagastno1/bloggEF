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
        var author = await _db.Authors.Where(a => a.Email == email && a.Password == password).FirstAsync();
        if(author == null)
        {
            throw new InvalidOperationException();
        }
        return author;
    }
}