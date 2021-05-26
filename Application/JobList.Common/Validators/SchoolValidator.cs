using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolRequest>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 300).WithMessage("Please specify a valid Name.");
        }
    }
}
