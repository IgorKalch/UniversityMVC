using MediatR;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Groups.Commands.Create
{
    public class CreateGroupCommand :  IRequest<Unit>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
        public Course? Course { get; set; }

        public CreateGroupCommand() {}

        public CreateGroupCommand(int id, int courseId, string name, List<Student>? students, Course? course) 
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            Students = students;
            Course = course;
        }
    }
}
