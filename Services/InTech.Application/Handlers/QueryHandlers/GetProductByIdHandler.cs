using MediatR;
using InTech.Application.Queries;
using InTech.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IMediator _mediator;

        public GetProductByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllProductQuery());
            var selectedProduct = customers.FirstOrDefault(x => x.Id == request.Id);
            return selectedProduct;
        }
    }
}
