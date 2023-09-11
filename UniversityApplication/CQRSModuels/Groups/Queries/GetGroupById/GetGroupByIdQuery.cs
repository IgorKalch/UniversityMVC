using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Groups.Queries.GetGroupById
{
    public class GetGroupByIdQuery : IRequest<Group>
    {
        public int Id { get; set; }

        public GetGroupByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
