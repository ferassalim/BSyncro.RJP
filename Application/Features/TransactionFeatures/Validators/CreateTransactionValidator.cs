using Application.Common.Validation;
using Application.Features.TransactionFeatures.Commands;
using FluentValidation;

namespace Application.Features.TransactionFeatures.Validators
{
    public class CreateTransactionValidator : CustomValidator<CreateTransactionCommand>
    {
        public CreateTransactionValidator()
        {
            RuleFor(p => p.CustomerId)
                .NotEmpty();
        }
    }
}
