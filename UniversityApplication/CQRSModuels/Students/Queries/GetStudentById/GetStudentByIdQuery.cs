using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
