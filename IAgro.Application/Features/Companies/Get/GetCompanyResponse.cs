using IAgro.Domain.Models;

namespace IAgro.Application.Features.Companies.Get;

public sealed record GetCompanyResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string CNPJ,
    string Country,
    List<Field> Fields
);