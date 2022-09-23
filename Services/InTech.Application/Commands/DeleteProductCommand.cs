using MediatR;
using System;

namespace InTech.Application.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public Int64 Id { get; private set; }

        public DeleteProductCommand(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
