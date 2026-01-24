namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class Tag
{
    [Key]
    public int TagKey { get; set; }

    [Required]
    public string TagTitle { get; set; } = string.Empty;

    public ICollection<JournalEntryTag> TagLinks { get; set; }
        = new List<JournalEntryTag>();
}