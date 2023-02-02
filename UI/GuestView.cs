using LOGIC;
using CORE;
namespace UI;
public class GuestView
{
    BlogService _blogService;
    PostService _postService;
    public GuestView(BlogService blogService, PostService postService)
    {
        _blogService = blogService;
        _postService = postService;
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
                    Task<IEnumerable<Blog>> loadingTopBlogs = Task.Run(async () => await _blogService.GetBlogsByRating());
                    while (!loadingTopBlogs.IsCompleted)
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("Loading blogs....");
                    }
                    loadingTopBlogs.Result.ToList().ForEach(b => Console.WriteLine(b.BlogNameToString()));
                    Console.ReadKey();
                    break;
                case 1:
                    string search = Input.GetString("Search blog/post/author: ");
                    try
                    {
                        Task<IEnumerable<Blog>> loadingSearchedBlogs = Task.Run(async () => await _blogService.GetBlogsBySearch(search));
                        while (!loadingSearchedBlogs.IsCompleted)
                        {
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("Loading result....");
                        }
                        Console.WriteLine("Ska fixa så att det som matchade tex spcifik post ska komma upp");
                        loadingSearchedBlogs.Result.ToList().ForEach(b => Console.WriteLine(b.BlogNameToString()));
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    try
                    {
                        Task<IEnumerable<Post>> loadingLatestPosts = Task.Run(async () => await _postService.GetLatestPosts());
                        while (!loadingLatestPosts.IsCompleted)
                        {
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("Loading result....");
                        }
                        Console.WriteLine("Ska fixa så att man kan komma in på dom");
                        loadingLatestPosts.Result.ToList().ForEach(p => Console.WriteLine(p.ToStringPublished()));
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    return;
            }
        }
    }
}