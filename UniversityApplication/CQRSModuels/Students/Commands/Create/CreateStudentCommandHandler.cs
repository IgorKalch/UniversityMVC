using AutoMapper;
using MediatR;
using UniversityApplication.DTOs;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Students.Commands.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateStudentCommandHandler(IUnitOfWork unit, IMapper mapper, IUserContext userContext)
        {
            _unit = unit;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var studentDTO = _mapper.Map<StudentDTO>(request);
            var student = _mapper.Map<Student>(studentDTO);
            student.CreatedById = user.Id;

            _unit.StudentRepository.Add(student);
            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
