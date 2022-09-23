using MediatR;
using InTech.Core.Entities;
using System;

namespace InTech.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Int64 Id { get; private set; }

        public GetProductByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}
