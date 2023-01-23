using CORE;
using LOGIC;
namespace UI;
public class AuthorView
{
    AuthorService _authorService;
    public AuthorView(AuthorService authorService)
    {
        _authorService = authorService;
    }
    public void AuthorMenu(Author author)
    {
        string[] options = new[] { "My blogs", "New Post", "Unpublished posts", "Add blog" };
        int optionNr = MenuArrows.Menu(options);
        switch (optionNr)
        {
            case 0: int i = 0;
             author.Blogs.ForEach(b => Console.WriteLine($"[{i+1}] {b.Name}"));
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
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
}