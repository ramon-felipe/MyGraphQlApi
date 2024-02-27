namespace MyGraphQl.Domain;

/// <summary>
/// A <see cref="Person"/>.
/// </summary>
public abstract class Person : BaseEntityWithName
{
    /// <summary>
    /// The person Age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// The <see cref="Person.LastName"/>.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}
