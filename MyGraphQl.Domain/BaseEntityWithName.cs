namespace MyGraphQl.Domain;

/// <summary>
/// Represents an Entity with a string Name.
/// </summary>
public abstract class BaseEntityWithName : BaseEntity
{
    /// <summary>
    /// The entity name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}