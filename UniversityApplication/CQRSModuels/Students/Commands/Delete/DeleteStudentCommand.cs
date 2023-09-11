using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityDataLayer.Entities;

namespace UniversityApplication.CQRSModuels.Students.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public Group? Group { get; set; }

        public DeleteStudentCommand(){}

        public DeleteStudentCommand(int id, int groupId, string? firstName, string? lastName, Group? group)
        {
            Id = id;
            GroupId = groupId;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
        }
    }
}
