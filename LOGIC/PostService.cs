using CORE;
namespace LOGIC;
public class PostService
{
    IRepository<Post> _postRepository;

    public PostService(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }
    public IEnumerable<Post> GetAllPosts()
    {
        var posts = _postRepository.GetAll();
        if (posts == null || posts.Count() < 1)
        {
            throw new ArgumentException("No posts found.");
        }
        return posts;
    }
    public Post GetPostById(int id)
    {
        var post = _postRepository.GetById(id);
        if (post == null)
        {
            throw new ArgumentException("No post found.");
        }
        return post;
    }
    public void UpdatePost(Post post)
    {
        _postRepository.Update(post);
    }
    public void DeletePost(int id)
    {
        var post = _postRepository.GetById(id);
        if (post == null)
        {
            throw new ArgumentException("No post found.");
        }
        _postRepository.Delete(post);
    }
}