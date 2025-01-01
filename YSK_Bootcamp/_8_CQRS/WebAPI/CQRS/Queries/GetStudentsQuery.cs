using MediatR;
using WebAPI.CQRS.Results;

namespace WebAPI.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
