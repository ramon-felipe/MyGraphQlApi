using MyGraphQl.Domain;

namespace MyGraphQl.HotChocolate.Api.Types;

/// <summary>
/// A process type
/// </summary>
public class ProcessType : ObjectType<Process>
{
    /// <summary>
    /// Configures <see cref="ProcessType"/>.
    /// </summary>
    /// <param name="descriptor"></param>
    protected override void Configure(IObjectTypeDescriptor<Process> descriptor)
    {
        descriptor.Description("A process object");

        descriptor.Implements<BaseTypeWithName>();
    }
}