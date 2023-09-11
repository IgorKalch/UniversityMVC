using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly IUnitOfWork _unit;

        public GetCourseByIdQueryHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken token)
        {
            var course = _unit.CourseRepository.GetById(request.Id);

            return await Task.FromResult(course);
        }
    }
}
