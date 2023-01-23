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
    public void AuthorMenu()
    {
       
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