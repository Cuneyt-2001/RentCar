using BusinessLayer;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeelingController : ControllerBase
    {
        FeelingBLL feelingbll = new FeelingBLL(new FeelingDAL());
        [HttpGet]
        public IActionResult Get()
        {
            // var claims = User.Claims;
            // var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);
            // var test = User.FindFirst(ClaimTypes.Email).Value;
            // Use the claims as needed.

            // var role = User.FindFirst(ClaimTypes.Role).Value;

           // var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);



            // Get the list of resources
            var resources = feelingbll.GetFeelings();

            // Return the list of resources as a JSON response
            return Ok(resources);

            return BadRequest();
        }


    }
}
