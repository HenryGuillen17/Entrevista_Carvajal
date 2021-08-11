using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserBackEnd.Domain.Contracts.Model;
using UserBackEnd.Domain.Contracts.Services;
using UserBackEnd.UserApi.Model;

namespace UserBackEnd.UserApi.Controllers
{
    /// <summary>
    /// Login Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        
        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="config"></param>
        /// <param name="userService"></param>
        public LoginController(
            IConfiguration config,
            IUserService userService
            )
        {
            _config = config;
            _userService = userService;
        }

        /**
         * Login Method
         */
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModelView login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user == null)
                return response;
            var tokenString = GenerateJwtToken(user);
            return Ok(new
            {
                token = tokenString,
                userDetails = user,
            });
        }

        private User AuthenticateUser(LoginModelView loginCredentials)
        {
            var dto = _userService.Login(new User
            {
                Email = loginCredentials.Email,
                Password = loginCredentials.Password
            });
            return dto;
        }

        private string GenerateJwtToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(_config.GetValue<double>("Jwt:Expire")),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    
}
