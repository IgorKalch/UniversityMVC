using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDataLayer.Entities
{
    public class Group : Entity
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public List<Student>? Students { get; set; }
        public Course? Course { get; set; }
    }
}
