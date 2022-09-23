using MediatR;
using System;

namespace InTech.Application.Commands
{
    public class DeleteUserCommand : IRequest<string>
    {
        public Int64 Id { get; private set; }

        public DeleteUserCommand(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
