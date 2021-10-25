using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto => new Address()
                        {City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode}));

            CreateMap<EditRestaurantDto, Restaurant>()
                .ForMember(e => e.Name, r => r.MapFrom(s => s.Name))
                .ForMember(e => e.Description, r => r.MapFrom(s => s.Description))
                .ForMember(e => e.HasDelivery, r => r.MapFrom(s => s.HasDelivery));
        }
    }
}
