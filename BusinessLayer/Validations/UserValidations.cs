using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            RuleFor(x => x.Name).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Email).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Password).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.Email).Matches(regex);
            RuleFor(x => x.Password).MinimumLength(1).WithMessage("Minimum Length of password 7");

        }
    }
}
