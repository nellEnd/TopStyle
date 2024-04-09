using AutoMapper;
using System.Security.Claims;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;

namespace TopStyle_Inlamning2.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserLoginDTO> Login(UserLoginDTO userDTO)
        {
            var user = await _repo.Login(userDTO);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

        }
    }
}
