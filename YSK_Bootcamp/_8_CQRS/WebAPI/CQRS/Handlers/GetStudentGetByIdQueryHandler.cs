using MediatR;
using WebAPI.CQRS.Queries;
using WebAPI.CQRS.Results;
using WebAPI.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.CQRS.Handlers
{
    public class GetStudentGetByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _studentContext;

        public GetStudentGetByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Students.FindAsync(request.Id);
            return new GetStudentByIdQueryResult()
            {
                Name = student.Name,
                Age = student.Age,
                Surname = student.Surname
            };
        }       
    }
}
