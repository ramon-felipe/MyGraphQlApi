using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Extensions;

namespace MyGraphQl.Infrastructure;

public interface IMyGraphQlContext
{
    DbSet<User> Users { get; set; } 
    DbSet<Process> Processes { get; set; } 

    DbSet<T> Set<T>() where T : class;
}

public class MyGraphQlContext : DbContext, IMyGraphQlContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Process> Processes { get; set; }

    public MyGraphQlContext(DbContextOptions<MyGraphQlContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ProcessUserMappingEntityTypeConfiguration).Assembly)
            .Seed();

        base.OnModelCreating(modelBuilder);
    }
}

//internal sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
//{
//    public void Configure(EntityTypeBuilder<User> builder)
//    {
//        builder
//            .HasMany(_ => _.UserProcesses)
//            .WithOne(_ => _.User)
//            .HasForeignKey(_ => _.UserId);
//    }
//}

//internal sealed class ProcessEntityTypeConfiguration : IEntityTypeConfiguration<Process>
//{
//    public void Configure(EntityTypeBuilder<Process> builder)
//    {
//        builder
//            .HasMany(_ => _.UserProcesses)
//            .WithOne(_ => _.Process)
//            .HasForeignKey(_ => _.ProcessId);
//    }
//}

internal sealed class ProcessUserMappingEntityTypeConfiguration : IEntityTypeConfiguration<ProcessUserMapping>
{
    public void Configure(EntityTypeBuilder<ProcessUserMapping> builder)
    {
        builder
            .HasKey(_ => new { _.UserId, _.ProcessId });
    }
}