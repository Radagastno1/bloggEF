namespace CORE;
public class Post
{
    public int PostId{get;set;}
    public string Title{get;set;}
    public string Content{get;set;}
    public DateTime DateCreated{get;set;}
    public DateTime DatePublished{get;set;}
    public bool IsPublished {get;set;} = false;
    public int BlogId{get;set;}
    public Blog Blog{get;set;}
    public Post(string aTitle, string aContent)
    {
        Title = aTitle;
        Content = aContent;
        DateCreated = DateTime.Now;
    }
    public Post(){}
}