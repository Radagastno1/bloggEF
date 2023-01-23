namespace CORE;
public class Author
{
    public int AuthorId{get;set;}
    public string Name{get;set;}
    public string Email{get;set;}
    public string Password{get;set;}
    public List<Blog> Blogs{get;set;}
    public Author(string aName, string aEmail, string aPassword)
    {
        Name = aName;
        Email = aEmail;
        Password = aPassword;
    }
    public Author(){}
}
