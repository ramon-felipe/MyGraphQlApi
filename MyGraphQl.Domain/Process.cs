using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

[Table("Processes")]
public class Process : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public virtual ICollection<ProcessUserMapping> UserProcesses { get; set; } = new HashSet<ProcessUserMapping>();
}
