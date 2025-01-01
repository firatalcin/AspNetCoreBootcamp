using MediatR;
using WebAPI.CQRS.Commands;
using WebAPI.Data;

namespace WebAPI.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public void Handle(RemoveStudentCommand command) 
        //{
        //    var student = _studentContext.Students.Find(command.Id);
        //    _studentContext.Students.Remove(student);
        //    _studentContext.SaveChanges();
        //}

        public async Task Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Students.FindAsync(request.Id);
            _studentContext.Students.Remove(student);
            await _studentContext.SaveChangesAsync();
        }
    }
}
