using MediatR;
using UserCRUD.Data.Entities;
using UserCRUD.Data.Repositories.UserRepository;
using UserCRUD.Domain.Queries.Request;

namespace UserCRUD.Domain.Queries.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GeAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GeAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers();
        }
    }
}
