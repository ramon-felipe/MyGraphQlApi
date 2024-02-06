using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;

namespace MyGraphQl.Infrastructure.Extensions;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Age = 30, Name = "Ra", LastName = "Arruda" },
            new User { Id = 2, Age = 35, Name = "Nah", LastName = "Laceranza" }
        );

        var process1 = new Process { Id = 1, Name = "Process 1",  };
        var process2 = new Process { Id = 2, Name = "Process 2" };

        modelBuilder.Entity<Process>().HasData(process1, process2);

        modelBuilder.Entity<ProcessUserMapping>().HasData(
            new ProcessUserMapping { UserId = 1, ProcessId = 1, HasAccess = true },
            new ProcessUserMapping { UserId = 1, ProcessId = 2, HasAccess = false },
            new ProcessUserMapping { UserId = 2, ProcessId = 2, HasAccess = true }
        );
    }
}
