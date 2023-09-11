using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Edit
{
    public class EditGroupCommandValidator : AbstractValidator<EditGroupCommand>
    {
        public EditGroupCommandValidator(IUnitOfWork unit, IStringLocalizer<EditGroupCommand> localizer)
        {
            RuleFor(x => x)
               .Custom((value, context) =>
               {
                   var existingCourse = unit.GroupRepository.Get(x => x.Name.ToLower() == value.Name.ToLower() && x.Id != value.Id).Any();

                   if (existingCourse)
                   {
                       context.AddFailure(localizer["NotUniqueName", value]);
                   }
               });

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20]);
                

            RuleFor(x => x.CourseId)
                .NotEmpty();
        }
    }
}
