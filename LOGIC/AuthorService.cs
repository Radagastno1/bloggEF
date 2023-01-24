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
        var taskSelectAll = Task.Run(async () => await _authorRepository.GetAllAsync());
        var authors = taskSelectAll.Result;
        if (authors == null || authors.Count() < 1)
        {
            throw new ArgumentException("No authors found.");
        }
        return authors;
    }
    public async Task<Author> GetAuthorById(int id)
    {
        return await _authorRepository.GetByIdAsync(id);
        // var author = selectingTask;
        // if (author == null)
        // {
        //     throw new ArgumentException("No author found.");
        // }
        // return author;
    }
    public async Task UpdateAuthor(Author author)
    {
        await _authorRepository.UpdateAsync(author);
    }
    public void DeleteAuthor(int id)
    {
        var author = GetAuthorById(id).Result;
        if (author == null)
        {
            throw new ArgumentException("Author not found.");
        }
        _authorRepository.DeleteAsync(author);
    }
    public async Task AddAuthorWithBlog(Author author, Blog blog)
    {
        int authorId = await _authorRepository.InsertAsync(author);
        blog.AuthorId = authorId;
        int blogId = _blogRepository.InsertAsync(blog).Result;
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