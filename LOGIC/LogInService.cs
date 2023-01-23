using CORE;
namespace LOGIC;
public class LogInService
{
    ILogInRepository _logInRepository;
    public LogInService(ILogInRepository logInRepository)
    {
        _logInRepository = logInRepository;
    }
    public Author TryLogIn(string email, string password)
    {
        var author = _logInRepository.TryLogIn(email, password);
        if(author == null)
        {
            throw new ArgumentException("Wrong password or email.");
        }
        return author;
    }
}