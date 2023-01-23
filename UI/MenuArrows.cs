namespace UI;
public class MenuArrows
{
    public static int Menu(string[] options)
    {
        int optionNr = 0;
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == optionNr)
                {
                    Console.WriteLine(">>" + options[i]);
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow && optionNr != options.Length - 1)
            {
                optionNr++;
            }
            else if (key == ConsoleKey.UpArrow && optionNr >= 1)
            {
                optionNr--;
            }
            else if (key == ConsoleKey.Enter)
            {
                return optionNr;
            }
        }
    }
}