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
        var posts = _postRepository.GetAllAsync().Result;
        if (posts == null || posts.Count() < 1)
        {
            throw new ArgumentException("No posts found.");
        }
        return posts;
    }
    public Post GetPostById(int id)
    {
        var post = _postRepository.GetByIdAsync(id).Result;
        if (post == null)
        {
            throw new ArgumentException("No post found.");
        }
        return post;
    }
    public void UpdatePost(Post post)
    {
        _postRepository.UpdateAsync(post);
    }
    public void DeletePost(int id)
    {
        var post = _postRepository.GetByIdAsync(id).Result;
        if (post == null)
        {
            throw new ArgumentException("No post found.");
        }
        _postRepository.DeleteAsync(post);
    }
    public void AddPost(Post post)
    {
        _postRepository.InsertAsync(post);
        
    }
}