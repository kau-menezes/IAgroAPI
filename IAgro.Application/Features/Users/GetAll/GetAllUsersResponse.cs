using IAgro.Domain.Common.Enums;

namespace IAgro.Application.Features.Users.GetAll;

public sealed record GetAllUsersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CompanyId,
    UserRole Role,
    string Email
);