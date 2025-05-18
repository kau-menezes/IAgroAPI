using IAgro.Application.Repositories.UsersRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Repositories.Users;

public class UsersRepository(IAgroContext context)
    : BaseRepository<User>(context), IUsersRepository
{
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        => context.Set<User>()
            .Where(entity => entity.DeletedAt == null)
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
}