using MediatR;
using WebAPI.CQRS.Results;

namespace WebAPI.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
