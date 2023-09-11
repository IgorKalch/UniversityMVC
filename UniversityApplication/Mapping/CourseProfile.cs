using AutoMapper;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using UniversityApplication.CQRSModuels.Courses.Commands.Delete;
using UniversityApplication.CQRSModuels.Courses.Commands.Edit;
using UniversityApplication.DTOs;
using UniversityApplication.User;
using UniversityDataLayer.Entities;

namespace UniversityApplication.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDTO, Course>();

            CreateMap<Course, CourseDTO>();

            CreateMap<CourseDTO, CreateCourseCommand>();

            CreateMap<CreateCourseCommand, CourseDTO>();

            CreateMap<EditCourseCommand, CourseDTO>();

            CreateMap<DeleteCourseCommand, Course>();

            CreateMap<Course, EditCourseCommand> ();

            CreateMap<Course, DeleteCourseCommand> ();
        }
    }
}
