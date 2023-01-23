namespace UI;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] options = new[] { "Visit as guest", "Sign in/sign up" };
        int optionNr = MenuArrows.Menu(options);
        switch(optionNr)
        {
            case 0:
            GuestView guestView = new();
            guestView.ShowBlogMenu();
            break;
            case 1:
            
            break;
        }
    }
}