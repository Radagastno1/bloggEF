namespace UI;
public class GuestView
{
    public void ShowBlogMenu()
    {
        string [] options = new[]{"Top blogs", "Search", "Latest posts", "Quit"};
        int optionNr = MenuArrows.Menu(options);
        switch(optionNr)
        {
            case 0:
            Console.WriteLine("Här ska topplistan visas. Alla bloggar ska bli ratade :)");
            break;
            case 1:
            break;
            case 2:
            break;
            case 3:
            break;
        }
    }
}