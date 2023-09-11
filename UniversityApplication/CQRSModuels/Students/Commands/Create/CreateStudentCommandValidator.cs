using FluentValidation;
using Microsoft.Extensions.Localization;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator(IStringLocalizer<CreateStudentCommand> localizer)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20]);



            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20]);
        }
    }
}
