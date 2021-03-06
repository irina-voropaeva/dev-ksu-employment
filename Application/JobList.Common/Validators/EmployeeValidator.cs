using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.PhotoMimeType).MaximumLength(5).WithMessage("Please specify a valid Photo Mime Type.");
            RuleFor(x => x.Sex).MaximumLength(1).WithMessage("Please specify a valid Sex.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please specify a valid Birth Date.");
            RuleFor(x => x.Email).NotEmpty().Length(6, 254).WithMessage("Please specify a valid Email.");
            RuleFor(x => x.Password).NotEmpty().Length(8, 100).WithMessage("Please specify a valid Password.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid Role Id.");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Please specify a valid City Id.");
        }
    }
}
