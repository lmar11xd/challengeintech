using InTech.Core.Entities;
using MediatR;
using System;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetUserByIdHandler : IRequest<User>
    {
        public Int64 Id { get; private set; }

        public GetUserByIdHandler(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
