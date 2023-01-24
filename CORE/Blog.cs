namespace CORE;
public class Blog
{
    public int BlogId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public DateTime DateCreated{get;set;}
    public int Ratings{get;set;}
    public List<Post> Posts{get;set;} = new();
    public int AuthorId{get;set;}
    public Author Author{get;set;}
    public Blog(string aName, string aDescription)
    {
        Name = aName;
        Description = aDescription;
        DateCreated = DateTime.Now; 
    }
    public Blog(){}
    public string BlogNameToString()
    {
        int i = 0;
        return $"[{i + 1} {Name}]";
    }

}