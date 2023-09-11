using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Delete
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Group>? Groups { get; set; } = default;

        public DeleteCourseCommand(){}

        public DeleteCourseCommand(int id, string name, string description, List<Group>? groups)
        {
            Id = id;
            Name = name;
            Description = description;
            Groups = groups;
        }
    }
}
