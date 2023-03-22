using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class LoanValidations : AbstractValidator<Loan>
    {
        public LoanValidations()
        {
            RuleFor(x => x.LoanDate).NotEmpty().WithMessage("this is required field");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("this is required field");
          
        }
    }
}
