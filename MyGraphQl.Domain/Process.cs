using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

/// <summary>
/// A process
/// </summary>
[Table("Processes")]
public class Process : BaseEntity
{
    /// <summary>
    /// The process name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// User process mappings<para/>
    /// Maps users x processes
    /// </summary>
    public virtual ICollection<ProcessUserMapping> UserProcesses { get; set; } = new HashSet<ProcessUserMapping>();
}
