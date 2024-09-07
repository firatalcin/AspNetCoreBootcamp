using MediatR;
using WebAPI.CQRS.Commands;
using WebAPI.Data;

namespace WebAPI.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentContext.Students.AddAsync(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _studentContext.SaveChangesAsync();
        }

        //public void Handler(CreateStudentCommand command)
        //{
        //    _studentContext.Students.Add(new Student { Age = command.Age, Name = command.Name, Surname = command.Surname });
        //    _studentContext.SaveChanges();
        //}
    }
}
