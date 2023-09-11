using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Edit
{
    public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public EditGroupCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditGroupCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();
            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var group = _unit.GroupRepository.GetById(request.Id);
            group.Name = request.Name;
            group.CourseId = request.CourseId;

            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
