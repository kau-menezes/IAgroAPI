using IAgro.Domain.Models;

namespace IAgro.Application.Repositories.UsersRepository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
}