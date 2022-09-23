using MediatR;
using InTech.Core.Entities;

namespace InTech.Application.Queries
{
    public class GetProductByNameQuery : IRequest<Product>
    {
        public string Name { get; private set; }

        public GetProductByNameQuery(string name)
        {
            this.Name = name;
        }

    }
}
