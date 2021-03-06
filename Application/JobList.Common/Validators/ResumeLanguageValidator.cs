using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class ResumeLanguageValidator : AbstractValidator<ResumeLanguageRequest>
    {
        public ResumeLanguageValidator()
        {
            RuleFor(x => x.ResumeId).NotEmpty().WithMessage("Please specify a valid Resume Id.");
            RuleFor(x => x.LanguageId).NotEmpty().WithMessage("Please specify a valid Language Id.");
        }
    }
}
