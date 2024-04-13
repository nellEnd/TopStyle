using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Core.Interfaces
{
    public interface IUserService
    {
        Task<object> Login(UserLoginDTO user);
        Task CreateUser (UserDTO user);
        Task <UserDTO>GetUser (string userId);
    }
}
