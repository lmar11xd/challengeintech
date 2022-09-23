using MediatR;
using InTech.Application.Queries;
using InTech.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, Product>
    {
        private readonly IMediator _mediator;

        public GetProductByNameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Product> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            var selectedProduct = products.FirstOrDefault(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            return selectedProduct;
        }
    }
}
