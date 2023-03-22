using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CarValidations : AbstractValidator<Car>
    {
        public CarValidations()
        {
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Body).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Year).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Model).NotEmpty().WithMessage("this is required field");
        
        }
    }
}
