using FluentValidation;
using WhatsAppCRM.Application.DTOs;

namespace WhatsAppCRM.Application.Validators
{
    public class MessageDtoValidator : AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\d{10,15}$");
            RuleFor(x => x.TextContent).NotEmpty().MaximumLength(4096);
        }
    }
}