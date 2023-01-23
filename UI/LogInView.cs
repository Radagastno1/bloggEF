using LOGIC;
using CORE;
namespace UI;
public class LogInView
{
    //ska göra interface sen?
    LogInService _logInService;
    public LogInView(LogInService logInService)
    {
        _logInService = logInService;
    }
    public Author LogIn()
    {
        string email = Input.GetEmail("Email: ");
        string password = Input.GetString("Password: ");
        var author = new Author();
        try
        {
            author = _logInService.TryLogIn(email, password);
           return author;
        }
        catch(ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        return author;
    }
}