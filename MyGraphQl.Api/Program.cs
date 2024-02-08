using GraphQL;
using MyGraphQl.Api.GraphQl;
using MyGraphQl.Api.GraphQl.Queries;
using MyGraphQl.Application.IoC;
using MyGraphQl.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQL(b => b
        .AddSystemTextJson()
        .AddSchema<MyGraphQlSchema>()
        .AddGraphTypes(typeof(MyGraphQlQuery).Assembly));

builder.Services
    .AddApplications()
    .AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapControllers();

// GraphQL Playground uses components of GraphiQL under the hood but is meant as a more powerful GraphQL IDE 
// https://github.com/graphql/graphql-playground/blob/main/packages/graphql-playground-react/README.md
app.UseGraphQL();
app.UseGraphQLPlayground();

app.Run();
