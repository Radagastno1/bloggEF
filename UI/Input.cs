using System.Net.Mail;
namespace UI;
public class Input
{
    static bool success = false;
    public static int GetInt(string output)
    {
        int number = 0;
        do
        {
            Console.WriteLine(output);
            success = int.TryParse(Console.ReadLine(), out number);
        } while (!success);
        return number;
    }
    public static string GetString(string output)
    {
        string text = string.Empty;
        do
        {
            Console.WriteLine(output);
            text = Console.ReadLine();
        } while (string.IsNullOrEmpty(text));
        return text;
    }
    public static string GetEmail(string output)
    {
        string email = string.Empty;
        do
        {
            Console.WriteLine(output);
            try
            {
                email = Console.ReadLine();
                MailAddress address = new MailAddress(email);
                success = true;
            }
            catch
            {
                success = false;
            }
        } while (!success);
        return email;
    }
}