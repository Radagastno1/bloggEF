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
        return _postRepository.GetAll();
    }
    public Post GetPostById(int id)
    {
        return _postRepository.GetById(id);
    }
    public void UpdatePost(Post post)
    {
        _postRepository.Update(post);
    }
    public void DeletePost(int id)
    {
        _postRepository.Delete(id);
    }
}