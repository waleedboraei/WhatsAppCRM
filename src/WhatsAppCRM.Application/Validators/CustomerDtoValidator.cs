using FluentValidation;
using WhatsAppCRM.Application.DTOs;

namespace WhatsAppCRM.Application.Validators
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\d{10,15}$");
        }
    }
}