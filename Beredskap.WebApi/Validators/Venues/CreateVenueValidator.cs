using Beredskap.DTOs.VenueDTOs;
using Beredskap.Domain.Entities;
using FluentValidation;

namespace Beredskap.WebApi.Validators
{
    public class CreateVenueValidator:AbstractValidator<CreateVenueRequest>
    {
        public CreateVenueValidator()
        {
            RuleFor(x => x.VenueName).NotEmpty();
            RuleFor(x => x.VenueDescription).NotEmpty();
        }
    }
}
