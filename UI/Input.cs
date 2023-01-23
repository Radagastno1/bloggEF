namespace UI;
public class Input
{
    public static int GetInt(string output)
    {
        bool success = false;
        int number = 0;
        do 
        {
            Console.WriteLine(output);
            success = int.TryParse(Console.ReadLine(), out number);
        }while(!success);
        return number;
    }
}