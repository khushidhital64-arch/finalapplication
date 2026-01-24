namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class JournalEntryTag
{
    [Key]
    public int LinkId { get; set; }

    public int EntryRefId { get; set; }
    public JournalEntry EntryRef { get; set; }

    public int RelatedTagId { get; set; }
    public Tag RelatedTag { get; set; }
}