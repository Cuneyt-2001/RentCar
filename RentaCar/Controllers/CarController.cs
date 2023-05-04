using BusinessLayer;
using BusinessLayer.Validations;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using DataAccessLayer.Interfaces;
using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Claims;

namespace RentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    
    public class CarController : ControllerBase
    {

        CarBLL carBLL = new CarBLL(new CarDAL());//
        UserBLL userBLL=new UserBLL(new UserDAL()); 

        [HttpGet]
        public IActionResult Get()
        {
           // var claims = User.Claims;
           // var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);
           // var test = User.FindFirst(ClaimTypes.Email).Value;
            // Use the claims as needed.

           // var role = User.FindFirst(ClaimTypes.Role).Value;

            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
           
            

                // Get the list of resources
                var resources = carBLL.GetCars();

                // Return the list of resources as a JSON response
                return Ok(resources);
            
            return BadRequest();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == false || true)
            {
                var userId = userBLL.GetuserIdByEmail(User.FindFirst(ClaimTypes.Email).Value);

                // Get the resource with the specified ID
                var resource = carBLL.GetCar(id);

                // If the resource is not found, return a 404 Not Found response
                if (resource == null)
                {
                    return NotFound();
                }

                // Return the resource as a JSON response
                return Ok(resource);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // var userClaims = User.Claims;
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true)
            {

                // Delete the resource
                var car = carBLL.GetCar(id);
                carBLL.RemoveAuto(car);

                // Return a no content response
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post( Car car)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true)
            {
                CarValidations validations = new CarValidations();
                ValidationResult result = validations.Validate(car);
                if (result.IsValid)
                {
                    // Create the new resource
                    var newcar = carBLL.AddCar(car);

                    // Return the newly created resource as a JSON response
                    return CreatedAtAction(nameof(Get), new { id = car.CarID }, car);
                }
            }
            return BadRequest();    
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,  Car car)
        {
            var access = userBLL.GetuserTypeByEmail(User.FindFirst(ClaimTypes.Email).Value);
            if (access == true)
            {

                var getcar = carBLL.GetCar(id);
                if (id != getcar.CarID)
                {
                    return NotFound();
                }

                if (getcar == null)
                {
                    return NotFound();
                }
                CarValidations validations = new CarValidations();
                ValidationResult result = validations.Validate(car);
                if (result.IsValid)
                {
                    car.CarID = id;
                    // Update the existing resource
                    var updatedResource = carBLL.EditAuto(car);

                    // Return the updated resource as a JSON response
                    if (updatedResource)
                    {
                        return Ok(car);
                    }
                    else
                    {

                    }
                }
            }
            return BadRequest();
        }




    }
}
