using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUniversity.Models;
using MediatR;
using UniversityApplication.CQRSModuels.Courses.Queries.GetAllCourse;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using UniversityApplication.CQRSModuels.Courses.Commands.Edit;
using UniversityApplication.CQRSModuels.Courses.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using WebUniversity.Extensions;
using UniversityApplication.CQRSModuels.Courses.Queries.GetCourseById;

namespace WebUniversity.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CourseController> _localizer;

        public CourseController(ILogger<CourseController> logger, IMediator mediator, IMapper mapper, IStringLocalizer<CourseController> localizer)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _localizer = localizer;
        }

        [Authorize(Roles = "User , Admin")]
        public async Task<IActionResult> Index()
        {
            var listOfCourses = await _mediator.Send(new GetAllCourseQuery());

            return View(listOfCourses.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [Route("Course/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery(id));

            EditCourseCommand model = _mapper.Map<EditCourseCommand>(course);

            return View(model);
        }

        [HttpPost]
        [Route("Course/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EditCourseCommand command)
        {           
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["EditSuccess", command.Name]);

                return RedirectToAction(nameof(Index));
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["EditError"]);

            return View(command);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, DeleteCourseCommand command)
        {
            if(command.Groups ==  null || command.Groups.Count == 0)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["DeleteSuccess"]);

                return RedirectToAction(nameof(Index));
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["DeleteError"]);

            return RedirectToAction(nameof(Index));

        }
    }
}