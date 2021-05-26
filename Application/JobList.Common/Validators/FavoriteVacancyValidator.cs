using FluentValidation;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.Common.Validators
{
    public class FavoriteVacancyValidator : AbstractValidator<FavoriteVacancyRequest>
    {
        public FavoriteVacancyValidator()
        {
            RuleFor(x => x.VacancyId).NotEmpty().WithMessage("Please specify a valid Vacancy Id.");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Please specify a valid Employee Id.");
        }
    }
}
