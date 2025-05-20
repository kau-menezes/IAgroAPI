using AutoMapper;
using MediatR;
using IAgro.Application.Common.Session;
using IAgro.Application.Common.Exceptions;
using IAgro.Domain.Common.Messages;
using IAgro.Application.Repositories.UsersRepository;

namespace IAgro.Application.Features.Users.GetAll;

public class GetAllUsersHandler(
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllUsersRequest, List<GetAllUsersResponse>>
{
    private readonly IUsersRepository usersRepository = usersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<GetAllUsersResponse>> Handle(
        GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();


        if (!session.IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var users = await usersRepository.GetAll(cancellationToken);

        return mapper.Map<List<GetAllUsersResponse>>(users);

    }
}