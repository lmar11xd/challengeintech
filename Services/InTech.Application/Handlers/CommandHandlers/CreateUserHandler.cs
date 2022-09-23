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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public CreateUserHandler(IUserCommandRepository userRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = InTechMapper.Mapper.Map<User>(request);

            //Encriptar Password 
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            if (userEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var id = await _userCommandRepository.AddAsync(userEntity);
            var newUser = await _userQueryRepository.GetByIdAsync(id);
            var userResponse = InTechMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
