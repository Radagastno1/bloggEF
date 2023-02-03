using LOGIC;
using CORE;
using Microsoft.EntityFrameworkCore;

namespace DATABASE.Repositories;
public class BlogRepository : IRepository<Blog>
{
    MyDbContext _db;
    public BlogRepository(MyDbContext db)
    {
        _db = db;
    }
    public async Task DeleteAsync(Blog blog)
    {
        _db.Blogs.Remove(blog);
        // await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _db.Blogs.ToListAsync();
    }
    public async Task<Blog> GetByIdAsync(int id)
    {
        return await _db.Blogs.FindAsync(id);
    }
    public async Task<int> InsertAsync(Blog blog)
    {
        await _db.Blogs.AddAsync(blog);
        // await _db.SaveChangesAsync();
        return blog.BlogId;
    }
    public async Task UpdateAsync(Blog blog)
    {
        await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<Blog>> GetBySearchAsync(string search)
    {
        return await _db.Blogs.Where(b => b.Name.Contains(search) || b.Description.Contains(search)).ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}