using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

[Table("ProcessUserMappings")]
public class ProcessUserMapping
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [ForeignKey("Process")]
    public int ProcessId { get; set; }
    public bool HasAccess { get; set; }

    //[UseSorting]
    public virtual User User { get; set; } = null!;
    public virtual Process Process { get; set; } = null!;
}