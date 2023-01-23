using CORE;
using Microsoft.EntityFrameworkCore;
namespace DATABASE;

public class MyDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }
    public MyDbContext() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string filePath = @"C:\Users\angel\Documents\suvnet22\OOP2\bloggEF\DATABASE\database.db";
        optionsBuilder.UseSqlite($"Data Source={filePath}");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Blog>(blog =>
        {
            blog.HasKey(b => b.BlogId);
            blog.HasMany(b => b.Posts).WithOne(p => p.Blog).OnDelete(DeleteBehavior.Cascade);
            blog.HasOne(b => b.Author).WithMany(a => a.Blogs).HasForeignKey(b => b.AuthorId);
        });
    }
}