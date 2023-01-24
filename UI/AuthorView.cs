using CORE;
using LOGIC;
namespace UI;
public class AuthorView
{
    AuthorService _authorService;
    BlogService _blogService;
    public AuthorView(AuthorService authorService, BlogService blogService)
    {
        _authorService = authorService;
        _blogService = blogService;
    }
    public Blog ChooseBlog(Author author)
    {
        author = _authorService.GetAuthorById(author.AuthorId);
        List<string> blogNameToList = new();
        foreach (Blog item in author.Blogs)
        {
            blogNameToList.Add(item.BlogNameToString());
        }
        string[] blogsNameToArray = blogNameToList.ToArray();
        int blogChoice = MenuArrows.Menu(blogsNameToArray);
        return author.Blogs[blogChoice];
    }
    public void AuthorMenu(Author author, Blog blog)
    {
        string[] options = new[] { "My blog", "New Post", "Unpublished posts", "Add blog" };
        while (true)
        {
            int optionNr = MenuArrows.Menu(options);
            switch (optionNr)
            {
                case 0:
                    Console.WriteLine(blog.Name);
                    Console.WriteLine();
                    Console.WriteLine(blog.Description);
                    try
                    {
                        blog.Posts.Where(p => p.IsPublished == true).ToList().ForEach(p => Console.WriteLine(p.ToStringPublished()));
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("No posts yet..");
                    }
                    Console.ReadKey();
                    break;
                case 1:
                    blog.Posts.Add(AddPost(blog));
                    Console.ReadKey();
                    break;
                case 2:
                try
                {
                    blog.Posts.Where(p => p.IsPublished == false).ToList().ForEach(p => Console.WriteLine(p.ToStringUnPublished()));
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("No unpublised posts..");
                }
                Console.ReadKey();
                    break;
                case 3:
                    break;
            }
        }

    }
    public void NewAuthor()
    {
        string name = Input.GetString("Name: ");
        string email = Input.GetEmail("Email: ");
        string password = Input.GetString("Password: ");
        Author author = new(name, email, password);
        string blogName = Input.GetString("Name your blog: ");
        string blogDescription = Input.GetString("Describe your blog: ");
        Blog blog = new(blogName, blogDescription);
        _authorService.AddAuthorWithBlog(author, blog);
    }
    public Post AddPost(Blog blog)
    {
        string title = Input.GetString("Title: ");
        string content = Input.GetString("Write post: ");
        Post post = new(title, content);
        post.BlogId = blog.BlogId;
        return post;
    }
}