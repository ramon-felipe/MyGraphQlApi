using MyGraphQl.Domain;

namespace MyGraphQl.HotChocolate.Api.Types;

/// <summary>
/// A process type
/// </summary>
public class ProcessType : ObjectType<Process>
{
    protected override void Configure(IObjectTypeDescriptor<Process> descriptor)
    {
        descriptor.Description("A process object");

        descriptor.Field(_ => _.Id).Type<IntType>();
        descriptor.Field(_ => _.Name).Type<StringType>();
    }
}