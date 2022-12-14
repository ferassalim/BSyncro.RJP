using System;
using Application.Common.Validation;
using Application.Features.CustomerFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerFeatures.Validators
{
    public class UpdateTransactionValidator : CustomValidator<UpdateCustomerCommand>
    {
        public UpdateTransactionValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(75);
            RuleFor(p => p.SureName).MaximumLength(100);
        }
    }
}

