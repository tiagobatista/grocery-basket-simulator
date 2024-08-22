using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public ISet<Item> Items { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasKey(i => i.Id);
    }
}
