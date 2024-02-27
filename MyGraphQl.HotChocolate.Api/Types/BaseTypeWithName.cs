using MyGraphQl.HotChocolate.Api.Interfaces;

namespace MyGraphQl.HotChocolate.Api.Types;

/// <summary>
/// A Base type containing ID and Name properties.
/// </summary>
public class BaseTypeWithName : InterfaceType<IBaseEntyWithName>
{
    /// <summary>
    /// Configures <see cref="BaseTypeWithName"/>.
    /// </summary>
    /// <param name="descriptor"></param>
    protected override void Configure(IInterfaceTypeDescriptor<IBaseEntyWithName> descriptor)
    {
        descriptor.Name("BaseTypeWithName");
    }
}