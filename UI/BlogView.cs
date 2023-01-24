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
    public Post AddPost(Blog blog)
    {
        Post post = new();
        string title = Input.GetString("Title: ");
        string content = Input.GetString("Write post: ");
        string published = Input.GetString("Publish now? y/n: ");
        if (published.ToLower() == "y")
        {
            post.IsPublished = true;
            post.DatePublished = DateTime.Now;
        }
        post = new(title, content);
        post.BlogId = blog.BlogId;
        _postService.AddPost(post);
        blog.Posts.Add(post);
        _blogService.UpdateBlog(blog);
        return post;
    }
    public Blog AddBlog(Author author)
    {
        string blogName = Input.GetString("Name of blog: ");
        //check if name not taken?
        string blogDescription = Input.GetString("Describe your blog: ");
        Blog blog = new(blogName, blogDescription);
        blog.AuthorId = author.AuthorId;
        int blogId = _blogService.AddBlog(blog);
        blog = _blogService.GetBlogById(blogId);
        return blog;
    }

}