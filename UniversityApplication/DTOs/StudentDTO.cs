using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.DTOs
{
    public class StudentDTO
    {
        public int GroupId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsEditable { get; set; }
    }
}
