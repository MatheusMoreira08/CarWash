using CarWash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Application.Interfaces;

public interface ICarWashDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<Session> Sessions { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
