using MyGraphQl.Domain;

namespace MyGraphQl.HotChocolate.Api.Types;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(_ => _.Id).Type<IntType>();
        descriptor.Field(_ => _.Name).Type<StringType>();
        descriptor.Field(_ => _.Age).Type<IntType>();
        descriptor.Field(_ => _.LastName).Type<StringType>();
    }
}

public class ProcessType : ObjectType<Process>
{
    protected override void Configure(IObjectTypeDescriptor<Process> descriptor)
    {
        descriptor.Field(_ => _.Id).Type<IntType>();
        descriptor.Field(_ => _.Name).Type<StringType>();
    }
}