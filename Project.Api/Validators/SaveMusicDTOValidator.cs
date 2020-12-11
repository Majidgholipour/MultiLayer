using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Project.Core.DTO;

namespace Project.Api.Validators
{
    public class SaveMusicDTOValidator:AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(a => a.ArtistId)
                .NotEmpty()
                .WithMessage("'Artist id' must not be 0");
        }
    }
}

