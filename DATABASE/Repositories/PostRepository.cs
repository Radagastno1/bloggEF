using LOGIC;
using CORE;

namespace DATABASE.Repositories;
public class PostRepository : IRepository<Post>
{
    MyDbContext _db;
    public PostRepository(MyDbContext db)
    {
        _db = db;
    }
    public void Delete(Post post)
    {
        _db.Posts.Remove(post);
    }
    public IEnumerable<Post> GetAll()
    {
        return _db.Posts;
    }
    public Post GetById(int id)
    {
        return _db.Posts.Find(id);
    }
    public int Insert(Post post)
    {
        _db.Posts.Add(post);
        _db.SaveChanges();
        return post.PostId;
    }
    public void Update(Post obj)
    {
        _db.SaveChanges();
    }

    IEnumerable<Post> IRepository<Post>.GetBySearch(string search)
    {
        return _db.Posts.Where(p => p.Content.Contains(search) || p.Title.Contains(search));
    }
}