using MediatR;
using InTech.Application.Commands;
using InTech.Core.Repositories.Command;
using InTech.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InTech.Application.Handlers.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        public DeleteProductHandler(IProductCommandRepository productRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productRepository;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productEntity = await _productQueryRepository.GetByIdAsync(request.Id);
                if(productEntity == null)
                {
                    return "Product not found";
                }

                await _productCommandRepository.DeleteAsync(productEntity.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Product information has been deleted!";
        }
    }
}
