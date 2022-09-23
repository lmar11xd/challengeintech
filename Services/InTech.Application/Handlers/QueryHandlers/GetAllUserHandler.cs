using InTech.Application.Queries;
using InTech.Core.Entities;
using InTech.Core.Repositories.Query;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetAllUserHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }
        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return (List<User>)await _userQueryRepository.GetAllAsync();
        }
    }
}
