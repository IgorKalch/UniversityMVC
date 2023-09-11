using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int Id { get; set; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
