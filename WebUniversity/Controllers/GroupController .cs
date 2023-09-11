using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using UniversityApplication.CQRSModuels.Groups.Commands.Create;
using UniversityApplication.CQRSModuels.Courses.Queries.GetCourseById;
using UniversityApplication.CQRSModuels.Groups.Queries.GetGroupById;
using UniversityApplication.CQRSModuels.Groups.Commands.Edit;
using UniversityApplication.CQRSModuels.Groups.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using UniversityDataLayer.Entities;
using WebUniversity.Extensions;
using WebUniversity.Models;
using Microsoft.Extensions.Localization;

namespace WebUniversity.Controllers
{
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GroupController> _localizer;

        public GroupController (ILogger<GroupController> logger, IMediator mediator, IMapper mapper, IStringLocalizer<GroupController> localizer)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _localizer = localizer;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int id)
        {
            var courseDto = await _mediator.Send(new GetCourseByIdQuery(id));

            var model = new CreateGroupCommand();
            model.CourseId = id;

            model.Course = _mapper.Map<Course>(courseDto);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateGroupCommand command)
        {

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["CreateSuccess", command?.Name]);

                return RedirectToAction("Index", "Course");
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["CreateError"]);

            return View(command);
        }

        [Route("Group/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var group = await _mediator.Send(new GetGroupByIdQuery(id));

            EditGroupCommand model = _mapper.Map<EditGroupCommand>(group);

            return View(model);
        }

        [HttpPost]
        [Route("Group/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EditGroupCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["EditSuccess", command.Name]);

                return RedirectToAction("Index", "Course");
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["EditError"]);

            return View(command);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _mediator.Send(new GetGroupByIdQuery(id));

            DeleteGroupCommand model = _mapper.Map<DeleteGroupCommand>(group);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, DeleteGroupCommand command)
        {
            if (command.Students == null || command.Students.Count == 0)
            {
                var group = await _mediator.Send(new GetGroupByIdQuery(id));
                command.CourseId = group.CourseId;

                await _mediator.Send(command);

                this.SetNotification(nameof(ENotificationType.success), _localizer["DeleteSuccess"]);

                return RedirectToAction("Index", "Course");
            }

            this.SetNotification(nameof(ENotificationType.error), _localizer["DeleteError"]);

            return RedirectToAction("Index", "Course");
        }
    }
}