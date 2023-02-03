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
            Task<Author> authorTask = Task.Run(async () => await _logInService.TryLogIn(email, password));
            while (!authorTask.IsCompleted)
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Trying to log in...");
            }
            author = authorTask.Result;
            return author;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}