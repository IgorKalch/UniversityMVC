using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IUnitOfWork _unit;

        public GetStudentByIdQueryHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken token)
        {
            var student = _unit.StudentRepository.GetById(request.Id);

            return await Task.FromResult(student);
        }

    }
}
