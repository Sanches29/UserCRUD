using Microsoft.EntityFrameworkCore;
using UserCRUD.Data.Entities;

namespace UserCRUD.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers() =>
            await _context.Users.ToListAsync();

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Attach(user);

            _context.Entry(user).Property(u => u.Name).IsModified = true;
            _context.Entry(user).Property(u => u.Email).IsModified = true;

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
