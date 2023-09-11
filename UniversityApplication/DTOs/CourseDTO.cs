using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.DTOs
{
    public class CourseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedById { get; set; }
        public bool IsEditable { get; set; }
    }
}
