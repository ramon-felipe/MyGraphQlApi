using GraphQL.Types;
using MyGraphQl.Domain;

namespace MyGraphQl.Api.GraphQl.Types;

public class UserProcessType : ObjectGraphType<ProcessUserMapping>
{
    public UserProcessType(/*IMyGraphQlContext myCtx*/)
    {
        this.Field(_ => _.UserId);
        this.Field(_ => _.ProcessId);
        this.Field(_ => _.HasAccess);
        //this.Field(_ => _.Process);
        
        //this.Field<UserType, User>("user").Resolve(ctx => myCtx.Users.FirstOrDefault(_ => _.Id == ctx.Source.UserId));
    }
}