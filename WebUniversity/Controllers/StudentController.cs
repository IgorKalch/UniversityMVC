using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using UniversityApplication.CQRSModuels.Students.Commands.Delete;
using UniversityApplication.CQRSModuels.Students.Commands.Edit;
using UniversityApplication.CQRSModuels.Students.Queries.GetStudentById;
using WebUniversity.Extensions;
using WebUniversity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebUniversity.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<StudentController> _localizer;

        public StudentController(ILogger<StudentController> logger, IMediator mediator, IMapper mapper, IStringLocalizer<StudentController> localizer)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _localizer = localizer;
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateStudentCommand();
            model.GroupId = id;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["CreateSuccess", command.FullName]);

                return RedirectToAction("Index", "Course");
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["CreateError"]);

            return View(command);
        }

        [Route("Student/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));

            var model = _mapper.Map<EditStudentCommand>(student);

            return View(model);
        }

        [HttpPost]
        [Route("Student/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EditStudentCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["EditSuccess", command.FullName]);

                return RedirectToAction("Index", "Course");
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["EditError"]);

            return View(command);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _mediator.Send(new GetStudentByIdQuery(id));

            var model = _mapper.Map<DeleteStudentCommand>(group);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, DeleteStudentCommand command)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            command.GroupId = student.GroupId;

            await _mediator.Send(command);

            this.SetNotification(nameof(ENotificationType.success), _localizer["DeleteSuccess"]);

            return RedirectToAction("Index", "Course");
        }
    }
}
