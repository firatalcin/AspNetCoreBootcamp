using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.CQRS.Commands;
using WebAPI.CQRS.Handlers;
using WebAPI.CQRS.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly GetStudentGetByIdQueryHandler _getStudentGetByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        //public StudentsController(GetStudentGetByIdQueryHandler getStudentGetByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentGetByIdQueryHandler = getStudentGetByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
