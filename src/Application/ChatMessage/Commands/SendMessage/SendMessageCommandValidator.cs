using FluentValidation;

namespace CleanArchitecture.Application
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator()
        {
            RuleFor(v => v.user)
                .MinimumLength(1)
                .NotEmpty();

            RuleFor(v => v.message)
                .MinimumLength(1)
                .NotEmpty();
        }
    }
}
