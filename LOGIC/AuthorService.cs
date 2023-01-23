using CORE;
namespace LOGIC;
public class AuthorService
{
    IRepository<Author> _authorRepository;

    public AuthorService(IRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public IEnumerable<Author> GetAllAuthors()
    {
        return _authorRepository.GetAll();
    }
}