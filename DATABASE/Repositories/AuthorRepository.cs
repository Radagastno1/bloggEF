using LOGIC;
using CORE;
namespace DATABASE.Repositories;
public class AuthorRepository : IRepository<Author>
{
    MyDbContext _db;
    public AuthorRepository(MyDbContext db)
    {
        _db = db;
    }
    public void Delete(Author author)
    {
        _db.Authors.Remove(author);
        _db.SaveChanges();
    }
    public IEnumerable<Author> GetAll()
    {
        return _db.Authors;
    }
    public Author GetById(int id)
    {
        return _db.Authors.Find(id);
    }
    public int Insert(Author author)
    {
        _db.Authors.Add(author);
        _db.SaveChanges();
        return author.AuthorId;
    }
    public void Update(Author author)
    {
        _db.SaveChanges();
    }
    IEnumerable<Author> IRepository<Author>.GetBySearch(string search)
    {
        return _db.Authors.Where(a => a.Name.Contains(search));
    }
}