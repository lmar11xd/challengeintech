using InTech.Application.Queries;
using InTech.Core.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly IMediator _mediator;

        public GetUserByUsernameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            var selectedUser = users.FirstOrDefault(x => x.Username.ToLower().Contains(request.Username.ToLower()));
            return selectedUser;
        }
    }
}
