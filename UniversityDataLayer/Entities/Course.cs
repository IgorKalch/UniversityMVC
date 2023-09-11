using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDataLayer.Entities
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public List<Group>? Groups { get; set; } = default;
    }
}
