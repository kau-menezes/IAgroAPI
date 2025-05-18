using IAgro.Domain.Common.Enums;

namespace IAgro.Domain.Objects;

public class SessionData
{
    public required Guid UserId { get; set; }
    public required Guid UserCompanyId { get; set; }
    public required UserRole Role { get; set; }
    public bool IsAdmin { get; set; } = false;
}