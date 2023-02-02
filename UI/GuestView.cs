using LOGIC;
using CORE;
namespace UI;
public class GuestView
{
    BlogService _blogService;
    public GuestView(BlogService blogService)
    {
        _blogService = blogService;
    }
    public async void ShowBlogMenu()
    {
        while (true)
        {
            string[] options = new[] { "Top blogs", "Search", "Latest posts", "Quit" };
            int optionNr = MenuArrows.Menu(options);
            switch (optionNr)
            {
                case 0:
                    Task<IEnumerable<Blog>> loadingBlogs = Task.Run(async () => await _blogService.GetBlogsByRating());
                    while (!loadingBlogs.IsCompleted)
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("Loading blogs....");
                    }
                    loadingBlogs.Result.ToList().ForEach(b => Console.WriteLine(b.BlogNameToString()));
                    Console.ReadKey();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    return;
            }
        }
    }
}