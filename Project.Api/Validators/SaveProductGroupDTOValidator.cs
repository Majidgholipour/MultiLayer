using FluentValidation;
using Project.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Api.Validators
{
    public class SaveProductGroupDTOValidator: AbstractValidator<SaveProductGroupDTO>
    {
        public SaveProductGroupDTOValidator()
        {
            RuleFor(a => a.Caption)
                .NotEmpty().WithMessage("productGroup Caption will be entered");
            RuleFor(a=>a.Code)
                .NotEmpty().WithMessage("productGroup Code will be entered");
        }
    }
}
