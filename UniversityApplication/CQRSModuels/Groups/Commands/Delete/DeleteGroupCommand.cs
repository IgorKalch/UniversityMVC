using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Delete
{
    public class DeleteGroupCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
        public Course? Course { get; set; }

        public DeleteGroupCommand(){}

        public DeleteGroupCommand(int id, int courseId, string name, List<Student>? students, Course? course)
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            Students = students;
            Course = course;
        }
    }
}
