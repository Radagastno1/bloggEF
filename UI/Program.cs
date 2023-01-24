using DATABASE.Repositories;
using LOGIC;
using CORE;
namespace UI;
internal class Program
{
    //TODO:
    //its not low coupling between logic and ui
    private static void Main(string[] args)
    {
        LogInService logInService = new(new LogInRepository(new DATABASE.MyDbContext()));
        AuthorService authorService = new(new AuthorRepository(new DATABASE.MyDbContext()), new BlogRepository(new DATABASE.MyDbContext()));
        BlogService blogService = new(new BlogRepository(new DATABASE.MyDbContext()));
        PostService postService = new(new PostRepository(new DATABASE.MyDbContext()));
        AuthorView authorView = new(authorService, blogService, postService);
        string[] options = new[] { "Visit as guest", "Sign in", "Sign up" };
        int optionNr = MenuArrows.Menu(options);
        switch (optionNr)
        {
            case 0:
                GuestView guestView = new();
                guestView.ShowBlogMenu();
                break;
            case 1:
                LogInView logInView = new(logInService);
                BlogView blogView = new(blogService, postService);
                var author = logInView.LogIn();
                if (author != null)
                {
                    Blog blog = authorView.ChooseBlog(author);
                    authorView = new(authorService, blogService, postService);
                    authorView.AuthorMenu(author, blog);
                }
                break;
            case 2:
                authorView = new(authorService, blogService, postService);
                authorView.NewAuthor();
                break;
        }
    }
}