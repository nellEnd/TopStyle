using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/login")]
        public async Task <IActionResult> Login(UserLoginDTO user)
        {
            try
            {
                return Ok(await _service.Login(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/register")]
        public async Task <IActionResult> CreateUser(UserDTO user)
        {
            try
            {
                await _service.CreateUser(user);
                return Ok("User successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/user")]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var user = await _service.GetUser(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
