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
        var authors = _authorRepository.GetAll();
        if (authors == null || authors.Count() < 1)
        {
            throw new ArgumentException("No authors found.");
        }
        return authors;
    }
    public Author GetAuthorById(int id)
    {
        var author = _authorRepository.GetById(id);
        if (author == null)
        {
            throw new ArgumentException("No author found.");
        }
        return author;
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
    public void AddAuthorWithBlog(Author author, Blog blog)
    {
        int authorId = _authorRepository.Insert(author);
        blog.AuthorId = authorId;
        int blogId = _blogRepository.Insert(blog);
        // AssignBlogToAuthor(authorId, blogId);
    }
    // public void AssignBlogToAuthor(int authorId, int blogId)
    // {
    //     Author author = _authorRepository.GetById(authorId);
    //     Blog blog = _blogRepository.GetById(blogId);
    //     author.Blogs.Add(blog);
    //     _authorRepository.Update(author);
    // }
}