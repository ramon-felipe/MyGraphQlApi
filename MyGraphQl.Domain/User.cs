using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

[Table("Users")]
public class User : Person
{
    // public virtual ICollection<Process> Processes { get; set; } = new HashSet<Process>();
    public virtual ICollection<ProcessUserMapping> UserProcesses { get; set; } = new HashSet<ProcessUserMapping>();

}
