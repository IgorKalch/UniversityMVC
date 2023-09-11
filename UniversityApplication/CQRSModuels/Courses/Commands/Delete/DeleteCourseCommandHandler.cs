using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Delete
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public DeleteCourseCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var course = _unit.CourseRepository.GetById(request.Id);

            _unit.CourseRepository.Remove(course);
            _unit.Commit();

            return  await Task.FromResult(Unit.Value);
        }
    }
}
