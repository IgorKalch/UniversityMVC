using AutoMapper;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using UniversityApplication.CQRSModuels.Students.Commands.Delete;
using UniversityApplication.CQRSModuels.Students.Commands.Edit;
using UniversityApplication.DTOs;
using UniversityDataLayer.Entities;

namespace UniversityApplication.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();

            CreateMap<StudentDTO, Student>();
            
            CreateMap<StudentDTO, CreateStudentCommand>();    
            
            CreateMap<CreateStudentCommand, StudentDTO>();            

            CreateMap<Student, DeleteStudentCommand>();

            CreateMap<Student, EditStudentCommand>();
        }
    }
}
