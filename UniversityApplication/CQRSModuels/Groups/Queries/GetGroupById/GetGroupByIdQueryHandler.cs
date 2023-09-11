using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, Group>
    {
        private readonly IUnitOfWork _unit;

        public GetGroupByIdQueryHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Group> Handle(GetGroupByIdQuery request, CancellationToken token)
        {
            var group = _unit.GroupRepository.GetById(request.Id);

            return await Task.FromResult(group);
        }
    }
}
