namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class JournalEntrySecondaryMood
{
    [Key]
    public int LinkId { get; set; }

    public int EntryRefId { get; set; }
    public JournalEntry EntryRef { get; set; }

    public int RelatedMoodId { get; set; }
    public Mood RelatedMood { get; set; }
}