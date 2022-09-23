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
    public class EditProductHandler : IRequestHandler<EditProductCommand, ProductResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        public EditProductHandler(IProductCommandRepository productRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productRepository;
            _productQueryRepository = productQueryRepository;
        }
        public async Task<ProductResponse> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = InTechMapper.Mapper.Map<Product>(request);

            if (productEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _productCommandRepository.UpdateAsync(productEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedProduct = await _productQueryRepository.GetByIdAsync(request.Id);
            var productResponse = InTechMapper.Mapper.Map<ProductResponse>(modifiedProduct);

            return productResponse;
        }
    }
}
