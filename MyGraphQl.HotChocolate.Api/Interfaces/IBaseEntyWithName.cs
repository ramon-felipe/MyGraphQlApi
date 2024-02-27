namespace MyGraphQl.HotChocolate.Api.Interfaces;

/// <summary>
/// IBaseEntyWithName interface
/// </summary>
public interface IBaseEntyWithName : IBaseEntityType
{
    /// <summary>
    /// A Name.
    /// </summary>
    public string Name { get; set; }
}