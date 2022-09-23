using MediatR;
using InTech.Core.Entities;
using System.Collections.Generic;

namespace InTech.Application.Queries
{
    public record GetAllProductQuery : IRequest<List<Product>>
    {

    }
}
