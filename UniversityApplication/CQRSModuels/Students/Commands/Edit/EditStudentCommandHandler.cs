using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Students.Commands.Edit
{
    public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public EditStudentCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditStudentCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var student = _unit.StudentRepository.GetById(request.Id);

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;

            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
