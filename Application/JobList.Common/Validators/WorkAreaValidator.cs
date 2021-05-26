using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class WorkAreaValidator : AbstractValidator<WorkAreaRequest>
    {
        public WorkAreaValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Please specify a valid Name.");
        }
    }
}
