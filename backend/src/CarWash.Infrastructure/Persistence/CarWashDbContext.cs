using Microsoft.EntityFrameworkCore;

namespace CarWash.Infrastructure.Persistence;

public class CarWashDbContext : DbContext
{
    public CarWashDbContext(DbContextOptions<CarWashDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        base.OnModelCreating(modelBuilder);
    }
}
