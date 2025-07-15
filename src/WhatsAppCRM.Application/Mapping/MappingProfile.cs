using AutoMapper;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Application.DTOs;

namespace WhatsAppCRM.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
