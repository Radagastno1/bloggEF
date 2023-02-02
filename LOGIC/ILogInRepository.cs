using CORE;
namespace LOGIC;
public interface ILogInRepository
{
    public Task<Author> TryLogInAsync(string email, string password);
}