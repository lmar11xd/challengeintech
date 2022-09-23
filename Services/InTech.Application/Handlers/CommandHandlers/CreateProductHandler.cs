using MediatR;
using InTech.Application.Commands;
using InTech.Application.Mapper;
using InTech.Application.Response;
using InTech.Core.Entities;
using InTech.Core.Repositories.Command;
using InTech.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        public CreateProductHandler(IProductCommandRepository productRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productRepository;
            _productQueryRepository = productQueryRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = InTechMapper.Mapper.Map<Product>(request);

            if (productEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var id = await _productCommandRepository.AddAsync(productEntity);
            var newProduct = await _productQueryRepository.GetByIdAsync(id);
            var productResponse = InTechMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
