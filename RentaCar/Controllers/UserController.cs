using BusinessLayer;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserBLL userbll = new UserBLL(new UserDAL());

        [HttpGet]
        [Authorize()]
        public IActionResult Get()
        {
            var access = userbll.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true)
            {

                // Get the list of resources
                var resources = userbll.GetAllUsers();

                // Return the list of resources as a JSON response
                return Ok(resources);
            }
            return BadRequest();    
        }
        [HttpGet("{email}")]
        public IActionResult GetuserIDbyEmail(string email)
        {
            var resources = userbll.GetuserIdByEmail(email);

            // Return the list of resources as a JSON response
            return Ok(resources);



        }




        [HttpPost("login")]
        //[Route("Checkuser")]
        [AllowAnonymous]
        public async Task<IActionResult> Checkuser(string email, string password)
        {
            // Get the list of resources
            var user = new User
            {
                Email = email,
                Password = password
            };
            var result = userbll.CheckUserInformation(user);

            // Return the list of resources as a JSON response
            if (result is not null)
            {

                var data = await GenerateToken(result);

                return Ok(data);
            }

            return BadRequest();

        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            UserValidations validate = new UserValidations();
            ValidationResult result = validate.Validate(user);
            if (result.IsValid)
            {
                // Create the new resource
                var user_ = userbll.CreateAccount(user);

                // Return the newly created resource as a JSON response
                return CreatedAtAction(nameof(Get), new { id = user.UserID }, user_);
            }
            return BadRequest();
        }

        private async Task<dynamic> GenerateToken(User user)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RENTACAR2023!!!!"));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name), // Set the username claim
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
              
                //new Claim(ClaimTypes.NameIdentifier, "12345"), // Set the ID claim
            };
            

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                expires: DateTime.Now.AddDays(10),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );


            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                userName = user.Name,
                role = user.Role,
                email=user.Email,
                userid=user.UserID,
                //userId =1 //user.UserID
            };

            return response;

        }
    }
}
