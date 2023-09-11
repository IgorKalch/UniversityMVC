using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDataLayer.Entities
{
    public class Student : Entity
    {
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        [NotMapped]
        public string FullName 
        { 
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public Group? Group { get; set; }
    }
}
