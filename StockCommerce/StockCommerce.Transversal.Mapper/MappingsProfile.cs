using AutoMapper;
using StockCommerce.Aplication.DTO;
using StockCommerce.Domain.Entities;

namespace StockCommerce.Transversal.Mapper
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile() 
        {
            CreateMap<prueba, PruebaDTO>().ReverseMap();
        }
    }
}
