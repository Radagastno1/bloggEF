using CORE;
namespace LOGIC;
public class BlogService
{
    IRepository<Blog> _blogRepository;

    public BlogService(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        var blogs = await _blogRepository.GetAllAsync();
        if (blogs == null || blogs.Count() < 1)
        {
            throw new ArgumentException("No blogs found.");
        }
        return blogs;
    }
    public async Task<IEnumerable<Blog>> GetBlogsByRating()
    {
        var blogs = await _blogRepository.GetAllAsync();

        if (blogs == null)
        {
            throw new ArgumentException("No blogs found.");
        }
        return blogs.OrderByDescending(b => b.Ratings);
    }
    public async Task<IEnumerable<Blog>> GetBlogsBySearch(string search)
    {
        var blogs = await _blogRepository.GetAllAsync();

        if (blogs == null)
        {
            throw new ArgumentException("No blogs found.");
        }
        var searchToLow = search.ToLower();
        var matchingBlogs = blogs.Where(b => b.Name.ToLower().Contains(searchToLow) || b.Author != null && b.Author.Name.ToLower().Contains(searchToLow) || b.Posts.Any(p => p.Title.ToLower().Contains(searchToLow) || p.Content.ToLower().Contains(searchToLow)));
       if(matchingBlogs == null)
       {
            throw new InvalidOperationException("Couldn't find any matches with your search..");
       }
       return matchingBlogs;
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
        var blog = _blogRepository.GetByIdAsync(id).Result;
        if (blog == null)
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