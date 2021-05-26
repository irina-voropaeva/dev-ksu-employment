using FluentValidation;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class CityValidator : AbstractValidator<CityRequest>
    {
        public CityValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Please specify a valid Name.");
        }
    }
}
