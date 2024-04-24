using MediatR;
using UserCRUD.Data.Entities;
using UserCRUD.Domain.Models;

namespace UserCRUD.Domain.Queries.Request
{
    public record GeAllUsersQuery() : IRequest<IEnumerable<User>>
    {
    }
}
