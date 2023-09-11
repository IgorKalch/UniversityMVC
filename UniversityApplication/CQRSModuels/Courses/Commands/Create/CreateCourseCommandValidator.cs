using FluentValidation;
using Microsoft.Extensions.Localization;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator(IUnitOfWork unit, IStringLocalizer<CreateCourseCommand> localizer) 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20])
                .Custom((value, context) =>
                {
                    var existingCourse = unit.CourseRepository.Get(x => x.Name.ToLower() == value.ToLower()).Any();

                    if (existingCourse)
                    {
                        context.AddFailure(localizer["NotUniqueName", value]);
                    }
                });

            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(localizer["DescriptionRequiredMessage"]);

        }
    }
}
