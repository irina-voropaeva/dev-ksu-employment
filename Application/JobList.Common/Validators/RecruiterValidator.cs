using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class RecruiterValidator : AbstractValidator<RecruiterRequest>
    {
        public RecruiterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.PhotoMimetype).MaximumLength(5).WithMessage("Please specify a valid Photo Mimetype.");
            RuleFor(x => x.Email).NotEmpty().Length(1, 254).WithMessage("Please specify a valid Email.");
            RuleFor(x => x.Password).NotEmpty().Length(1, 100).WithMessage("Please specify a valid Password.");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Please specify a valid  Company Id.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid ");
        }
    }
}
