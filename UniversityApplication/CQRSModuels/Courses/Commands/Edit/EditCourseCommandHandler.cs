using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Edit
{
    public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public EditCourseCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditCourseCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || !user.IsInRole("Admin")
                 || (request.Groups != null && request.Groups.Count > 0))
            {
                return await Task.FromResult(Unit.Value);
            }

            var course = _unit.CourseRepository.GetById(request.Id);
            
            course.Name = request.Name;
            course.Description = request.Description;

            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
