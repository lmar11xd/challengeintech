using InTech.Core.Entities;
using MediatR;
using System;

namespace InTech.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Int64 Id { get; private set; }

        public GetUserByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }
    }
}
