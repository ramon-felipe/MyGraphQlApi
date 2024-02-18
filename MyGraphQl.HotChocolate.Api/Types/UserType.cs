using MyGraphQl.Domain;

namespace MyGraphQl.HotChocolate.Api.Types;

/// <summary>
/// A user
/// </summary>
public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Description("A user object");

        descriptor.Field(_ => _.Id).Type<IntType>().Description("The user id");
        descriptor.Field(_ => _.Name).Type<StringType>().Description("The user name");
        descriptor.Field(_ => _.Age).Type<IntType>().Description("The user age");
        descriptor.Field(_ => _.LastName).Type<StringType>().Description("The user last name");
    }
}
