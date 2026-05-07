namespace CarWash.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool Active { get; set; } = true;

    public int FailedLoginAttempts { get; set; }

    public DateTime? BlockedUntil { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
