using Beredskap.DTOs.TenantDTOs;
using FluentValidation;

namespace Beredskap.WebApi.Validators.Tenants
{
    public class UpdateTenantValidator: AbstractValidator<UpdateTenantRequest>
    {
        public UpdateTenantValidator()
        {
            RuleFor(x => x.Key).NotEmpty();
        }
    }
}
