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
  
    public class LoanController : ControllerBase
    {
        LoanBLL loanbll = new LoanBLL(new LoanDAL());
        UserBLL userBLL=new UserBLL(new UserDAL()); 

        [HttpGet]
        public IActionResult Get()
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true )
            {

                // Get the list of resources
                var resources = loanbll.GetAll();

                // Return the list of resources as a JSON response
                return Ok(resources);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == false)
            {
                // Get the resource with the specified ID
                var resource = loanbll.GetLoanbyUser(id);

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
        public IActionResult Post(Loan loan)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true || false)
            {




                LoanValidations loanValidations = new LoanValidations();
                ValidationResult validationResult = loanValidations.Validate(loan);
                if (validationResult.IsValid)
                {
                    // Create the new resource
                    var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);
                    loan.UserID = userId;
                    var newloan = loanbll.AddLoan(loan);
                    if (newloan == 0)
                    {
                        return BadRequest();
                    }

                    // Return the newly created resource as a JSON response
                    return CreatedAtAction(nameof(Get), new { id = loan.LoanID }, loan);
                }
            }
            return BadRequest();
        }


    }
}
