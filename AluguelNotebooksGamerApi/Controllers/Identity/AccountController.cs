using AluguelNotebooksGamerApi.Entities.Identity;
using AluguelNotebooksGamerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AluguelNotebooksGamerApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IConfiguration configuration,
                            RoleManager<IdentityRole> roleManager) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = new ApplicationUser
                {
                    UserName = model.Email,
                    Password = model.Password,
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is null)
                {
                    return NotFound();
                }

                var token = GenerateJWTToken(user);

                return Ok(new { token = token, user = user });
            }

            if (result.RequiresTwoFactor)
            {
            }

            return BadRequest();
        }

        [HttpGet]
        [Authorize(Policy = "RequireUserAdminGerenteRole")]
        public IActionResult GetAllUsers()
        {
            if (ModelState.IsValid)
            {
                var usersList = userManager.Users;

                return Ok(usersList);
            }

            return BadRequest();
        }

        private string GenerateJWTToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("/email", user.Email),
                }),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:ValidOn"],
                Expires = DateTime.Now.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
