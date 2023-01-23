using CORE;
namespace LOGIC;
public interface ILogInRepository
{
    public Author TryLogIn(string email, string password);
}