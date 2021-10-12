using AutoMapper;
using CleanArchMVC.Application.DTO;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;

namespace CleanArchMVC.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
