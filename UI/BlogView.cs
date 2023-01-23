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