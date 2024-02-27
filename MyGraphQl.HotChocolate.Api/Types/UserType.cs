using MyGraphQl.Domain;

namespace MyGraphQl.HotChocolate.Api.Types;

/// <summary>
/// A user
/// </summary>
public class UserType : ObjectType<User>
{
    /// <summary>
    /// Configures <see cref="UserType"/>.
    /// </summary>
    /// <param name="descriptor"></param>
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Description("A user object");

        descriptor.Implements<BaseTypeWithName>();

        descriptor.Field(_ => _.Age).Type<IntType>();
        descriptor.Field(_ => _.LastName).Type<StringType>();
    }
}
