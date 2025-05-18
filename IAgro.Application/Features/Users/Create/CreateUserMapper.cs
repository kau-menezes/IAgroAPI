using AutoMapper;
using IAgro.Domain.Models;

namespace IAgro.Application.Features.Users.Create;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}