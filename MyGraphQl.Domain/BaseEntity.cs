using System.ComponentModel.DataAnnotations;

namespace MyGraphQl.Domain;

/// <summary>
/// A base entity.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// The Entity ID.
    /// </summary>
    [Key]
    public int Id { get; set; }
}
