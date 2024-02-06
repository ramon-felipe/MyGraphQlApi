using System.ComponentModel.DataAnnotations;

namespace MyGraphQl.Domain;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
