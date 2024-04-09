using TopStyle_Inlamning2.Domain.DTO;

namespace TopStyle_Inlamning2.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginDTO> Login(UserLoginDTO user);
    }
}
