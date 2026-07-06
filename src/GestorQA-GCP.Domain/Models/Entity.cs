namespace GestorQA_GCP.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAtUtc { get; set; }
}