namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class Mood
{
    public enum MoodCategory
    {
        Positive,
        Neutral,
        Negative
    }

    [Key]
    public int MoodKey { get; set; }

    [Required]
    public string MoodTitle { get; set; } = string.Empty; // Happy, Sad, Calm

    [Required]
    public MoodCategory Category { get; set; }

    public ICollection<JournalEntry> MainEntries { get; set; }
        = new List<JournalEntry>();

    public ICollection<JournalEntrySecondaryMood> ExtraEntries { get; set; }
        = new List<JournalEntrySecondaryMood>();
}