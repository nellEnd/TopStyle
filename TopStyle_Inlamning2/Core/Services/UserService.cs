using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

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

        public async Task CreateUser(UserDTO user)
        {
            var newUser = _mapper.Map<User>(user);

           await _repo.CreateUser(newUser);

            //return _mapper.Map<UserLoginDTO> (await _repo.CreateUser(newUser));
        }

        public async Task<object> Login(UserLoginDTO userDTO)
        {
            var user = await _repo.Login(userDTO);

            if (user == null)
                throw new Exception("Login failed.");

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            // Hantera nyckeln i Aure keyvault ist!!!!!!!!!!
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5157/",
                audience: "http://localhost:5157/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new {Token= tokenString};

        }
    }
}
