using UserCRUD.Data.Entities;

namespace UserCRUD.Data.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(Guid id);
    }
}
