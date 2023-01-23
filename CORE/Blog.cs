namespace CORE;
public class Blog
{
    public int BlogId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public DateTime DateCreated{get;set;}
    public List<Post> Posts{get;set;}
    public int AuthorId{get;set;}
    public Author Author{get;set;}
    public Blog(string aName, string aDescription)
    {
        Name = aName;
        Description = aDescription;
        DateCreated = DateTime.Now; 
    }
    public Blog(){}
}