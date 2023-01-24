using CORE;
using LOGIC;
namespace UI;
public class BlogView
{
    BlogService _blogService;
    public BlogView(BlogService blogService)
    {
        _blogService = blogService;
    }
    public Post AddPost(Blog blog)
    {
        string title = Input.GetString("Title: ");
        string content = Input.GetString("Write post: ");
        Post post = new(title, content);
        post.BlogId = blog.BlogId;
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