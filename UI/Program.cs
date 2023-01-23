using DATABASE.Repositories;
using LOGIC;
namespace UI;
internal class Program
{
    private static void Main(string[] args)
    {
        LogInService logInService = new(new LogInRepository(new DATABASE.MyDbContext()));
        AuthorService authorService = new(new AuthorRepository(new DATABASE.MyDbContext()), new BlogRepository(new DATABASE.MyDbContext()));
AuthorView authorView = new(authorService);
        string[] options = new[] { "Visit as guest", "Sign in", "Sign up" };
        int optionNr = MenuArrows.Menu(options);
        switch(optionNr)
        {
            case 0:
            GuestView guestView = new();
            guestView.ShowBlogMenu();
            break;
            case 1:
            LogInView logInView = new(logInService);
            var author = logInView.LogIn();
            if(author != null)
            {
                authorView = new(authorService);
            }
            break;
            case 2:
            authorView = new(authorService);
            authorView.NewAuthor();
            break;
        }
    }
}