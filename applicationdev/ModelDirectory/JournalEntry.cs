namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class JournalEntry
{
    [Key]
    public int JournalId { get; set; }

    [Required]
    public DateTime JournalDate { get; set; }

    public string BodyText { get; set; } = string.Empty;

    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }

    // ============== USER =================
    public int OwnerId { get; set; }          // Foreign Key
    public User Owner { get; set; }

    // ============ PRIMARY MOOD ============
    public int MainMoodId { get; set; }
    public Mood MainMood { get; set; }

    // ============ SECONDARY MOODS =========
    public ICollection<JournalEntrySecondaryMood> ExtraMoods { get; set; }
        = new List<JournalEntrySecondaryMood>();

    // ================= TAGS ===============
    public ICollection<JournalEntryTag> EntryTags { get; set; }
        = new List<JournalEntryTag>();

    public int TotalWordCount { get; set; }
}