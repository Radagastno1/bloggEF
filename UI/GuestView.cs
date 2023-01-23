namespace UI;
public class GuestView
{
    public void ShowBlogMenu()
    {
        string [] options = new[]{"Top-listan", "Sök", "Senaste blogg-inläggen", "Avsluta"};
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