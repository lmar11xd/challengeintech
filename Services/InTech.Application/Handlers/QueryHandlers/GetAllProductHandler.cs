using MediatR;
using InTech.Application.Queries;
using InTech.Core.Entities;
using InTech.Core.Repositories.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.QueryHandlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public GetAllProductHandler(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }
        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return (List<Product>)await _productQueryRepository.GetAllAsync();
        }
    }
}
