namespace UI;
//använder ej
public class Menu
{
    public event Action<string> OnChoiceSelected;
    List<string> _options;
    public Menu(List<string> options)
    {
        _options = options;
    }
    public void ActionWhenOptionSelected(string choice)
    {
        OnChoiceSelected?.Invoke(choice);
    }
    public string GetOptionSelected(int nr)
    {
        return _options[nr - 1];
    }
    public void ShowMenu()
    {
        for(int i = 0; i < _options.Count(); i++)
        {
            Console.WriteLine($"[{i + 1}] {_options[i]}");
        }
    }
}