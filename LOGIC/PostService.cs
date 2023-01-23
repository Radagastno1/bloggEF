using CORE;
namespace LOGIC;
public class PostService
{
    IRepository<Post> _postRepository;

    public PostService(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }
}