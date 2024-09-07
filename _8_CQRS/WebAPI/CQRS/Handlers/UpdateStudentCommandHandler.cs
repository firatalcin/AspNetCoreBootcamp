using MediatR;
using WebAPI.CQRS.Commands;
using WebAPI.Data;

namespace WebAPI.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updateStudent = await _studentContext.Students.FindAsync(request.Id);
            updateStudent.Name = request.Name;
            updateStudent.Surname = request.Surname;
            updateStudent.Age = request.Age;
            await _studentContext.SaveChangesAsync();
        }

        //public void Handler(UpdateStudentCommand command)
        //{
        //    var updateStudent = _studentContext.Students.Find(command.Id);
        //    updateStudent.Surname = command.Surname;
        //    updateStudent.Name = command.Name;
        //    updateStudent.Age = command.Age;

        //    _studentContext.SaveChanges();

        //}
    }
}
