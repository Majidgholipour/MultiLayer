using FluentValidation;
using Project.Core.DTO;

namespace Project.Api.Validators
{
    public class SaveArtistDTOValidator:AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'Name Length ");
        }
    }
}
