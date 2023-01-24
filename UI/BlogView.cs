using CORE;
using LOGIC;
namespace UI;
public class BlogView
{
    BlogService _blogService;
    PostService _postService;
    public BlogView(BlogService blogService, PostService postService)
    {
        _blogService = blogService;
        _postService = postService;
    }
    public async Task<Post> AddPost(Blog blog)
    {
        Post post = new();
        post.Title = Input.GetString("Title: ");
        post.Content = Input.GetString("Write post: ");
        string published = Input.GetString("Publish now? y/n: ");
        if (published.ToLower() == "y")
        {
            post.IsPublished = true;
            post.DatePublished = DateTime.Now;
        }
        post.BlogId = blog.BlogId;
        // Task<Blog> insertTask = await _postService.AddPost(post);
        blog.Posts.Add(post);
        _blogService.UpdateBlog(blog);
        return post;
    }
    public async Task<Blog> AddBlog(Author author)
    {
        string blogName = Input.GetString("Name of blog: ");
        //check if name not taken?
        string blogDescription = Input.GetString("Describe your blog: ");
        Blog blog = new(blogName, blogDescription);
        blog.AuthorId = author.AuthorId;

        Task<int> insertTask = Task.Run(async () => await _blogService.AddBlogAsync(blog));
        while(!insertTask.IsCompleted)
        {
            Console.SetCursorPosition(0,8);
            Console.WriteLine("Loading blog....");
        }
        int blogId = insertTask.Result;
        blog = _blogService.GetBlogById(blogId);
        return blog;
    }

}