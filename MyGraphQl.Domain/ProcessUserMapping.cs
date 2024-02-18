using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGraphQl.Domain;

/// <summary>
/// An object representing the mapping between <see cref="User"/> and <see cref="Process"/>
/// </summary>
[Table("ProcessUserMappings")]
public class ProcessUserMapping //: BaseEntity
{
    /// <summary>
    /// The <see cref="User"/> Id
    /// </summary>
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    /// <summary>
    /// The <see cref="Process"/> ID.
    /// </summary>
    [ForeignKey("Process")]
    public int ProcessId { get; set; }

    /// <summary>
    /// Indicates if a user has access to the process
    /// </summary>
    public bool HasAccess { get; set; }

    //[UseSorting]
    /// <summary>
    /// The <see cref="User"/> associated with the <see cref="Process"/>
    /// </summary>
    public virtual User User { get; set; } = null!;

    /// <summary>
    /// The <see cref="Process"/> associated with the <see cref="User"/>
    /// </summary>
    public virtual Process Process { get; set; } = null!;
}