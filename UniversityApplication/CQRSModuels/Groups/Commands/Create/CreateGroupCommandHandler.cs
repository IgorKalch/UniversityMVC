using AutoMapper;
using MediatR;
using UniversityApplication.DTOs;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Create
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateGroupCommandHandler(IUnitOfWork unit, IMapper mapper, IUserContext userContext)
        {
            _unit = unit;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();

            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var groupDTO = _mapper.Map<GroupDTO>(request);
            var group = _mapper.Map<Group>(groupDTO);
            group.CreatedById = user.Id;

            _unit.GroupRepository.Add(group);
            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
