using MediatR;
using InTech.Application.Response;
using System;

namespace InTech.Application.Commands
{
    public class EditProductCommand : IRequest<ProductResponse>
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
