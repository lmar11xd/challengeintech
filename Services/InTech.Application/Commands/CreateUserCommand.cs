using InTech.Application.Response;
using MediatR;

namespace InTech.Application.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
