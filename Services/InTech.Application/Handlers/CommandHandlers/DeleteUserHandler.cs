using InTech.Application.Commands;
using InTech.Core.Repositories.Command;
using InTech.Core.Repositories.Query;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public DeleteUserHandler(IUserCommandRepository userRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = await _userQueryRepository.GetByIdAsync(request.Id);
                if (userEntity == null)
                {
                    return "User not found";
                }

                await _userCommandRepository.DeleteAsync(userEntity.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "User information has been deleted!";
        }
    }
}
