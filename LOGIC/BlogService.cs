using CORE;
namespace LOGIC;
public class BlogService
{
    IRepository<Blog> _blogRepository;

    public BlogService(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public IEnumerable<Blog> GetAllBlogs()
    {
        return _blogRepository.GetAll();
    }
    public Blog GetBlogById(int id)
    {
        return _blogRepository.GetById(id);
    }
    public void UpdateBlog(Blog blog)
    {
        _blogRepository.Update(blog);
    }
    public void DeleteBlog(int id)
    {
        var blog = _blogRepository.GetById(id);
        if(blog == null)
        {
            throw new ArgumentException("No blog found.");
        }
        _blogRepository.Delete(blog);
    }
}