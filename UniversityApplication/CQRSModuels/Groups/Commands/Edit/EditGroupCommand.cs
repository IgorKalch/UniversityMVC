using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Edit
{
    public class EditGroupCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
        public Course? Course { get; set; }

        public EditGroupCommand() {}

        public EditGroupCommand(int id, int courseId, string name, List<Student>? students, Course? course)
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            Students = students;
            Course = course;
        }
    }
}
