using CORE;
namespace LOGIC;
public class BlogService
{
    IRepository<Blog> _blogRepository;

    public BlogService(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }
}