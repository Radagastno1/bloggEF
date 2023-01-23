using CORE;
namespace LOGIC;
public class AuthorService
{
    IRepository<Author> _authorRepository;
    IRepository<Blog> _blogRepository;

    public AuthorService(IRepository<Author> authorRepository, IRepository<Blog> blogRepository)
    {
        _authorRepository = authorRepository;
        _blogRepository = blogRepository;
    }
    public IEnumerable<Author> GetAllAuthors()
    {
        return _authorRepository.GetAll();
    }
    public Author GetAuthorById(int id)
    {
        return _authorRepository.GetById(id);
    }
    public void UpdateAuthor(Author author)
    {
        _authorRepository.Update(author);
    }
    public void DeleteAuthor(int id)
    {
        var author = GetAuthorById(id);
        if (author == null)
        {
            throw new ArgumentException("Author not found.");
        }
        _authorRepository.Delete(author);
    }
    public void AssignBlogToAuthor(int authorId, int blogId)
    {
        Author author = _authorRepository.GetById(authorId);
        Blog blog = _blogRepository.GetById(blogId);
        author.Blogs.Add(blog);
        _authorRepository.Update(author);
    }
}