using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

/// <summary>
/// A process
/// </summary>
[Table("Processes")]
public class Process : BaseEntityWithName
{
    /// <summary>
    /// User process mappings<para/>
    /// Maps users x processes
    /// </summary>
    public virtual ICollection<ProcessUserMapping> UserProcesses { get; set; } = new HashSet<ProcessUserMapping>();
}
