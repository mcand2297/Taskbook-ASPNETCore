using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Taskbook_ASPNETCore.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Taskbook_ASPNETCore.Controllers{

    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase{
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration
        ){
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User model){
            if(ModelState.IsValid){
                var user = new User {UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.PasswordHash);
                if(result.Succeeded){
                    return BuildToken(model);
                }else{
                    return BadRequest("UserName or Password invalid");
                }
            }else{
                return BadRequest(ModelState);
            }
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> SignIn([FromBody] User  userInfo){
            if(ModelState.IsValid){
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.PasswordHash, isPersistent:false, lockoutOnFailure: false);
                if(result.Succeeded) return BuildToken(userInfo);
                else{
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }else{
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(User userInfo)
        {
            var claims = new[]
            {
                new Claim( JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(48);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "ApiAuth:Issuer",
               audience: "ApiAuth:Audience",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }

    }
}