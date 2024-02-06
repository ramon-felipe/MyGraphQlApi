namespace MyGraphQl.Domain;

public abstract class Person : BaseEntity
{
    public int Age { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
