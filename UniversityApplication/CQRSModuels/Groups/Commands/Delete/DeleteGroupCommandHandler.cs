using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Delete
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IUserContext _userContext;

        public DeleteGroupCommandHandler(IUnitOfWork unit, IUserContext userContext)
        {
            _unit = unit;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();

            if (user == null || !user.IsInRole("Admin") 
                || (request.Students != null && request.Students.Count > 0))
            {
                return await Task.FromResult(Unit.Value);
            }

            var group = _unit.GroupRepository.GetById(request.Id);

            _unit.GroupRepository.Remove(group);
            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
