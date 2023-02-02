using LOGIC;
using CORE;
using Microsoft.EntityFrameworkCore;

namespace DATABASE.Repositories;
public class PostRepository : IRepository<Post>
{
    MyDbContext _db;
    public PostRepository(MyDbContext db)
    {
        _db = db;
    }
    public async Task DeleteAsync(Post post)
    {
        _db.Posts.Remove(post);
    }
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await _db.Posts.ToListAsync();
    }
    public async Task<Post> GetByIdAsync(int id)
    {
        return await _db.Posts.FindAsync(id);
    }
    public async Task<int> InsertAsync(Post post)
    {
        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return post.PostId;
    }
    public async Task UpdateAsync(Post obj)
    {
        await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<Post>> GetBySearchAsync(string search)
    {
        return await _db.Posts.Where(p => p.Content.Contains(search) || p.Title.Contains(search)).ToListAsync();
    }
}