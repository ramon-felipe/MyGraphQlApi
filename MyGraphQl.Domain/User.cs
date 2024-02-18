using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

/// <summary>
/// An object representing a User
/// </summary>
[Table("Users")]
public class User : Person
{
    // public virtual ICollection<Process> Processes { get; set; } = new HashSet<Process>();
    /// <summary>
    /// The user processes.
    /// </summary>
    public virtual ICollection<ProcessUserMapping> UserProcesses { get; set; } = new HashSet<ProcessUserMapping>();

}
