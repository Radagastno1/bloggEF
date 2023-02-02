using LOGIC;
namespace UI;
public class GuestView
{
    BlogService _blogService;
    public GuestView(BlogService blogService)
    {
        _blogService = blogService;
    }
    public void ShowBlogMenu()
    {
        while (true)
        {
            string[] options = new[] { "Top blogs", "Search", "Latest posts", "Quit" };
            int optionNr = MenuArrows.Menu(options);
            switch (optionNr)
            {
                case 0:
                    _blogService.GetBlogsByRating().ToList().ForEach(b => Console.WriteLine(b.BlogNameToString()));
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