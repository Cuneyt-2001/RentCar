using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class ReviewValidations : AbstractValidator<Review>
    {
        public ReviewValidations()
        {
            RuleFor(x => x.Reviewcontent).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Reviewcontent).MinimumLength(10).WithMessage("Minimum Length of characters 1");
           // RuleFor(x => x.Reviewcontent).MaximumLength(50).WithMessage("Maximum Length of characters 50");



        }
    }
}
