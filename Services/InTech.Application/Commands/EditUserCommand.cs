using InTech.Application.Response;
using MediatR;
using System;

namespace InTech.Application.Commands
{
    public class EditUserCommand : IRequest<UserResponse>
    {
        public Int64 Id { get; set; }
        public string Username { get; set; }
    }
}
