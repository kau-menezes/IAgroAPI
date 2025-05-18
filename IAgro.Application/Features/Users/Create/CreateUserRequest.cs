using IAgro.Domain.Common.Enums;
using MediatR;

namespace IAgro.Application.Features.Users.Create;

public sealed record CreateUserRequest(
    Guid CompanyId,
    string Email,
    string Password,
    UserRole Role
) : IRequest<CreateUserResponse>;