using BusinessLayer;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarReviewController : ControllerBase
    {
        ReviewBLL reviewbll = new ReviewBLL(new ReviewDAL());
        UserBLL userBLL = new UserBLL(new UserDAL());
        LoanBLL loanbll=new LoanBLL(new LoanDAL());



        [HttpGet("{carId}")]      
        public IActionResult GetReviews(int carId)
        {

            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access ==   false)

            {

                var resource = loanbll.GetAllReviews_(carId);

                // If the resource is not found, return a 404 Not Found response
                if (resource == null)
                {
                    return NotFound();
                }

                // Return the resource as a JSON response
                return Ok(resource);
            }
            return BadRequest();
        }


    }
}
