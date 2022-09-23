using MediatR;
using InTech.Application.Response;
using System;

namespace InTech.Application.Commands
{
    public class CreateProductCommand: IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
