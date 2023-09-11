using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Courses.Queries.GetAllCourse
{
    public class GetAllCourseQuery : IRequest<IEnumerable<Course>>
    {
    }
}
