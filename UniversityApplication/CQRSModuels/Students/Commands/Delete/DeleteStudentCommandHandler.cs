using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Students.Commands.Delete
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public DeleteStudentCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();

            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }
            var student = _unit.StudentRepository.GetById(request.Id);

            _unit.StudentRepository.Remove(student);
            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
