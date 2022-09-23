using InTech.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace InTech.Application.Queries
{
    public class GetAllUserQuery : IRequest<List<User>>
    {
    }
}
