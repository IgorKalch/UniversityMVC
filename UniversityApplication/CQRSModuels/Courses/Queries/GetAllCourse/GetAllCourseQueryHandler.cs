using AutoMapper;
using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Queries.GetAllCourse
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IEnumerable<Course>>
    {
        private readonly IUnitOfWork _unit;

        public GetAllCourseQueryHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<Course>> Handle(GetAllCourseQuery request, CancellationToken token)
        {
            var listCourses = _unit.CourseRepository.Get();
            
            foreach (var course in listCourses)
            {
                course.Groups = _unit.GroupRepository.Get(x => x.CourseId == course.Id).ToList();

                foreach (var group in course.Groups)
                {
                    group.Students = _unit.StudentRepository.Get(x => x.GroupId == group.Id).ToList();
                }
            }

            return await Task.FromResult(listCourses);
        }
    }
}
