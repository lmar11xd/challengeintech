using AutoMapper;
using InTech.Application.Commands;
using InTech.Application.Response;
using InTech.Core.Entities;

namespace InTech.Application.Mapper
{
    public class InTechMappingProfile : Profile
    {
        public InTechMappingProfile()
        {
            //Product
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, EditProductCommand>().ReverseMap();

            //User
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, EditUserCommand>().ReverseMap();

            //Order
        }
    }
}
