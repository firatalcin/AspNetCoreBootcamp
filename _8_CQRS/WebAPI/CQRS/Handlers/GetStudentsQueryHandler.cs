using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.CQRS.Queries;
using WebAPI.CQRS.Results;
using WebAPI.Data;

namespace WebAPI.CQRS.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentContext.Students
               .Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname })
               .AsNoTracking().ToListAsync();

            return students;
        }
       

        //public IEnumerable<GetStudentsQueryResult> Handler(GetStudentsQuery query)
        //{
        //    var students = _studentContext.Students
        //        .Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname})
        //        .AsNoTracking().AsEnumerable();

        //    return students;
        //}


    }
}
