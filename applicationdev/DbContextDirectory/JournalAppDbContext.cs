using applicationdev.ModelDirectory;
namespace applicationdev.DbContextDirectory;
using Microsoft.EntityFrameworkCore;

public class JournalAppDbContext : DbContext
{
    public JournalAppDbContext(DbContextOptions<JournalAppDbContext> options) : base(options)
    {
    }

    public DbSet<User> AppUsers { get; set; }
    public DbSet<JournalEntry> Entries { get; set; }
    public DbSet<Tag> EntryTags { get; set; }
    public DbSet<JournalEntryTag> EntryTagLinks { get; set; }
    public DbSet<Mood> EntryMoods { get; set; }
    public DbSet<JournalEntrySecondaryMood> EntrySecondaryMoods { get; set; }
}

