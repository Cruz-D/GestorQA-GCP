using GestorQA_GCP.Application.Abstractions.Services;

namespace GestorQA_GCP.Infrastructure.Services;

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}