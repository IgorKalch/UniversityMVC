using FluentValidation;
using Microsoft.Extensions.Localization;
using UniversityApplication.CQRSModuels.Groups.Commands.Create;
using UniversityApplication.CQRSModuels.Students.Commands.Edit;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {
        public EditStudentCommandValidator(IStringLocalizer<EditStudentCommand> localizer)
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
