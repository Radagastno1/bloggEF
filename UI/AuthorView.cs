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
        int optionNr = MenuArrows.Menu(options);
        switch (optionNr)
        {
            case 0:
                //gå till blogview?
                Console.WriteLine(blog.Name);
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