using LOGIC;
using CORE;

namespace DATABASE.Repositories;
public class BlogRepository : IRepository<Blog>
{
    MyDbContext _db;
    public BlogRepository(MyDbContext db)
    {
        _db = db;
    }
    public void Delete(Blog blog)
    {
        _db.Blogs.Remove(blog);
        _db.SaveChanges();
    }
    public IEnumerable<Blog> GetAll()
    {
        return _db.Blogs;
    }
    public Blog GetById(int id)
    {
        return _db.Blogs.Find(id);
    }
    public int Insert(Blog blog)
    {
        _db.Blogs.Add(blog);
        _db.SaveChanges();
        return blog.BlogId;
    }
    public void Update(Blog blog)
    {
        _db.SaveChanges();
    }

    IEnumerable<Blog> IRepository<Blog>.GetBySearch(string search)
    {
       return _db.Blogs.Where(b => b.Name.Contains(search) || b.Description.Contains(search));
    }
}