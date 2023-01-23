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
        var blogs = _blogRepository.GetAll();
        if(blogs == null || blogs.Count() < 1)
        {
            throw new ArgumentException("No blogs found.");
        }
        return blogs;
    }
    public Blog GetBlogById(int id)
    {
        var blog =  _blogRepository.GetById(id);
        if(blog == null)
        {
            throw new ArgumentException("No blog found.");
        }
        return blog;
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