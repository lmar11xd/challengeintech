
using InTech.Application.Commands;
using InTech.Application.Mapper;
using InTech.Application.Response;
using InTech.Core.Entities;
using InTech.Core.Repositories.Command;
using InTech.Core.Repositories.Query;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.CommandHandlers
{
    public class EditUserHandler : IRequestHandler<EditUserCommand, UserResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public EditUserHandler(IUserCommandRepository userRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userRepository;
            _userQueryRepository = userQueryRepository;
        }
        public async Task<UserResponse> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = InTechMapper.Mapper.Map<User>(request);

            if (userEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _userCommandRepository.UpdateAsync(userEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedUser = await _userQueryRepository.GetByIdAsync(request.Id);
            var userResponse = InTechMapper.Mapper.Map<UserResponse>(modifiedUser);

            return userResponse;
        }
    }
}
