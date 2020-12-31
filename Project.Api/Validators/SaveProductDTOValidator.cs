using FluentValidation;
using Project.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Api.Validators
{
    public class SaveProductDTOValidator: AbstractValidator<SaveProductDTO>
    {
        public SaveProductDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50).WithMessage("Product name must be enterd");
            RuleFor(a => a.Code)
                .NotEmpty()
                .MaximumLength(6).WithMessage("product Code must be 6 characters.")
                .MinimumLength(6).WithMessage("product Code must be 6 characters.");
        }
    }
}
