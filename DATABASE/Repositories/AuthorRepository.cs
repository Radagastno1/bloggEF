using LOGIC;
using CORE;
using Microsoft.EntityFrameworkCore;
namespace DATABASE.Repositories;
public class AuthorRepository : IRepository<Author>
{
    MyDbContext _db;
    public AuthorRepository(MyDbContext db)
    {
        _db = db;
    }
    public async Task DeleteAsync(Author author)
    {
        _db.Authors.Remove(author);
        // await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _db.Authors.ToListAsync();
    }
    public async Task<Author> GetByIdAsync(int id)
    {
        return await _db.Authors.Include(a => a.Blogs.Where(b => b.AuthorId == id)).FirstAsync(a => a.AuthorId == id);
    }
    public async Task<int> InsertAsync(Author author)
    {
        _db.Authors.Add(author);
        // await _db.SaveChangesAsync();
        return author.AuthorId;
    }
    public async Task UpdateAsync(Author author)
    {
        await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<Author>> GetBySearchAsync(string search)
    {
        return await _db.Authors.Include(a => a.Blogs).Where(a => a.Name.Contains(search)).ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}