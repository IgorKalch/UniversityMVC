using AutoMapper;
using MediatR;
using UniversityApplication.DTOs;
using UniversityApplication.User;
using UniversityDataLayer.Entities;
using UniversityDataLayer.UnitOfWorks;

namespace UniversityApplication.CQRSModuels.Courses.Commands.Create
{
    public class CreateCourseCommandHandler: IRequestHandler<CreateCourseCommand, Unit>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCourseCommandHandler(IUnitOfWork unit, IMapper mapper, IUserContext userContext)
        {
            _unit = unit;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCourseCommand request, CancellationToken token)
        {
            var user = _userContext.GetCurrentUser();

            if (user == null || !user.IsInRole("Admin"))
            {
                return await Task.FromResult(Unit.Value);
            }

            var courseDTO = _mapper.Map<CourseDTO>(request);
            var course = _mapper.Map<Course>(courseDTO);

            course.CreatedById = user.Id;

             _unit.CourseRepository.Add(course);
            _unit.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
