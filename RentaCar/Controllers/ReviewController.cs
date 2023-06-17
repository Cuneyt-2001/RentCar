using BusinessLayer;
using BusinessLayer.Validations;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.ViewModels;
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
        LoanBLL loanbll = new LoanBLL(new LoanDAL());
     


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
        public IActionResult Post(ReviewAddViewModel model)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            

            if (string.IsNullOrEmpty(model.ReviewContent))
            {

            }

            var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);

            var review = new Review
            {
                CarID= model.CarId,
                Reviewcontent =model.ReviewContent,
                UserID = userId
            };

            var reviewResult = reviewbll.AddReview(review, model.FeelingIds);



            if (reviewResult > 0)
            {
                return Ok();
            }

            return BadRequest();
        }



    }
}
