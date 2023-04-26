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
    public class ReviewController : ControllerBase
    {
        ReviewBLL reviewbll = new ReviewBLL(new ReviewDAL());
        UserBLL userBLL = new UserBLL(new UserDAL());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == false || true)
            {
                // Get the resource with the specified ID
                var resource = reviewbll.GetReviewbyID(id);

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
        [HttpPost]

        public IActionResult Post(Review review)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == false || true)
            {


                ReviewValidations validate = new ReviewValidations();
                ValidationResult validationResult = validate.Validate(review);
                if (validationResult.IsValid)
                {
                    // Create the new resource
                    var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);
                    review.UserID = userId;

                    var newcar = reviewbll.AddReview(review);
                    if (newcar > 0)
                    {
                        return Ok();
                    }
                }

                //var errorMessages = new List<string>();
                //errorMessages.AddRange(validationResult.Errors.Select(a=>a.ErrorMessage));
                //return BadRequest(new { success = false, errorMessages });
            }
            return BadRequest();
        }
    }
}
