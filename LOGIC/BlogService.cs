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
    public async Task<Blog> GetBlogById(int id)
    {
        return await _blogRepository.GetByIdAsync(id);
    }
    public void UpdateBlog(Blog blog)
    {
        _blogRepository.UpdateAsync(blog);
    }
    public void DeleteBlog(int id)
    {
        var blog = _blogRepository.GetByIdAsync(id);
        if(blog == null)
        {
            throw new ArgumentException("No blog found.");
        }
        _blogRepository.DeleteAsync(blog);
    }
    public async Task<int> AddBlogAsync(Blog blog)
    {
        return await _blogRepository.InsertAsync(blog);
    }
    
}