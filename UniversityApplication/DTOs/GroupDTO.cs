using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.DTOs
{
    public class GroupDTO
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public bool IsEditable { get; set; }
    }
}
