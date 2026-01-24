namespace applicationdev.ModelDirectory;
using System.ComponentModel.DataAnnotations;
public class User
{
    [Key]
    public int UserKey { get; set; }

   
    public string LoginId { get; set; } = string.Empty;

    [Required]
    public string SecretHash { get; set; } = string.Empty;

    [Required]
    [EmailAddress] 
    public string MailAddress { get; set; } = string.Empty;

    // ONE user → MANY journal entries
    public ICollection<JournalEntry> UserJournals { get; set; }
        = new List<JournalEntry>();
}