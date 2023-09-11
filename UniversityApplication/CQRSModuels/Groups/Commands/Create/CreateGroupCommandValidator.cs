using FluentValidation;
using Microsoft.Extensions.Localization;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Create
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator(IUnitOfWork unit, IStringLocalizer<CreateGroupCommand> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage(localizer["MinimumLengthErrorMessage", 3])
                .MaximumLength(20).WithMessage(localizer["MaximumLengthErrorMessage", 20])
                .Custom((value, context) =>
                {
                    var existingGroup = unit.GroupRepository.Get(x => x.Name.ToLower() == value.ToLower()).Any();

                    if (existingGroup)
                    {
                        context.AddFailure(localizer["NotUniqueName", value]);
                    }
                });

            RuleFor(x => x.Course)
                .NotEmpty();
        }
    }
}
