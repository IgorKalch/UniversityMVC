using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Groups.Queries.GetGroupsByCourseId
{
    public class GetGroupsByCourseIdQuery : IRequest<IEnumerable<Group>>
    {
        public int Id { get; }

        public GetGroupsByCourseIdQuery(int id)
        {
            Id = id;
        }
    }
}
