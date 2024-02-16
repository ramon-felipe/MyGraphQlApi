namespace MyGraphQl.Domain;

public abstract class Person : BaseEntity
{
    /// <summary>
    /// The person Age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// The person Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The <see cref="Person.LastName"/>.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}
