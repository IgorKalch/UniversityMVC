using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Edit
{
    public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
    {
        public EditCourseCommandValidator(IUnitOfWork unit, IStringLocalizer<EditCourseCommand> localizer)
        {
            RuleFor(x => x)                
                .Custom((value, context) =>
                {
                    var existingCourse = unit.CourseRepository.Get(x => x.Name.ToLower() == (value.Name??value.Name.ToLower()) && x.Id != value.Id).Any();

                    if (existingCourse)
                    {
                        context.AddFailure(localizer["NotUniqueName", value]);
                    }
                });

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20]);

            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(localizer["DescriptionRequiredMessage"]);
        }
    }
}
