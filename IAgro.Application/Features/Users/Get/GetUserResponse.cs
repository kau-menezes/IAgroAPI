using IAgro.Domain.Common.Enums;

namespace IAgro.Application.Features.Users.Get;

public sealed record GetUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CompanyId,
    UserRole Role,
    string Email
);