using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TopStyleContext _context;

        public UserRepo(TopStyleContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            //return user;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public async Task<User> Login(UserLoginDTO user)
        {
            var loginUser = _context.Users.FirstOrDefault(u => u.Username.ToLower() == user.UserName.ToLower()
            && u.Password.ToLower() == user.Password.ToLower());

            return loginUser;
        }
    }
}
