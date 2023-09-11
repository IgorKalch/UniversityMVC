using MediatR;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Groups.Queries.GetGroupsByCourseId
{
    public class GetGroupsByCourseIdHandler : IRequestHandler<GetGroupsByCourseIdQuery, IEnumerable<Group>>
    {
        private readonly IUnitOfWork _unit;

        public GetGroupsByCourseIdHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<Group>> Handle(GetGroupsByCourseIdQuery request, CancellationToken token)
        {
            var groups = _unit.GroupRepository.Get(x => x.Id == request.Id);
            
            foreach (var group in groups)
            {
                group.Course = _unit.CourseRepository.Get(x => x.Id == group.CourseId).FirstOrDefault();
                group.Students = _unit.StudentRepository.Get(x => x.GroupId == group.Id).ToList();
            }

            return await Task.FromResult(groups);
        }
    }
}
