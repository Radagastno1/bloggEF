using CORE;
namespace LOGIC;
public class LogInService
{
    ILogInRepository _logInRepository;
    public LogInService(ILogInRepository logInRepository)
    {
        _logInRepository = logInRepository;
    }
    public async Task<Author> TryLogIn(string email, string password)
    {
        try
        {
            var author = await _logInRepository.TryLogInAsync(email, password);
            return author;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Sign in unsuccesful.");
        }
    }
}